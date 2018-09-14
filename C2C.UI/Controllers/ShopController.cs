using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C2C.Data;
using C2C.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace C2C.UI.Controllers
{
    public class ShopController : Controller
    {
        public readonly ApplicationDbContext _context;
        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RemoveFromCart(string cartItemId)
        {
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }
            Cart cart = GetCart(owner);

            var cartItemToRemove = cart.CartItems.Where(ci => ci.Id == cartItemId).FirstOrDefault();

            if (cartItemToRemove != null)
            {
                cart.CartItems.Remove(cartItemToRemove);
                _context.SaveChanges();
            }
            return RedirectToAction("Cart");
        }

        public IActionResult AddToCart(string productId)
        {
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }
            Cart cart = GetCart(owner);
            CartItem cartItem = cart.CartItems.Where(c => c.ProductId == productId).FirstOrDefault();

            if (cartItem == null)
            {
                cartItem = new CartItem();
                cartItem.ProductId = productId;
                cartItem.Quantity = 1;
                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += 1;
            }
            _context.SaveChanges();
            HttpContext.Session.SetString("CartId", cart.Id.ToString());
            return RedirectToAction("Cart");
        }

        public IActionResult Cart()
        {
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }
            Cart cart = GetCart(owner);
            return View(cart);
        }

        // sepete göre yeni sipariş yaratır
        [Authorize]
        public IActionResult Checkout(string errorCode = "")
        {
            Cart cart = GetCart(HttpContext.Session.Id);
            if (cart == null || cart.CartItems.Count == 0)
            {
                cart = GetCart(User.Identity.Name);
            }
            if (cart == null || cart.CartItems.Count == 0)
            {
                return RedirectToAction("Cart");
            }
            ViewBag.ErrorCode = errorCode;
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                return RedirectToAction("Login", "Account");
            }
            var order = GetOrder(owner);
            
            return View(order);
        }
        // sipariş kaydını ödeme onayı bekleniyor şeklinde günceller
        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                return RedirectToAction("Login", "Account");
            }
            order.Cart = GetCart(owner);
            order.Cart.Owner = owner;
            if (ModelState.IsValid)
            {
                order.OrderStatus = OrderStatus.Delayed; // ödeme onayı bekleniyor
               if (order.PaymentMethod == "BankTransfer")
                {
                    _context.Update(order);
                    _context.SaveChanges();
                    return RedirectToAction("CheckoutCompleted", new { orderId = order.Id });
                }
                else if (order.PaymentMethod == "CC")
                {
                    _context.Orders.Update(order);
                    _context.SaveChanges();
                    return IyzicoPayment(order);
                }
                
            }
            return View(order);
        }
        private IActionResult IyzicoPayment(Order order)
        {
            Options options = new Options();
            options.ApiKey = "PVKewvZEgJf8UGUeYoj5FeT1nMhQk4ep";
            options.SecretKey = "Lk69QlCFmwR3mDnfnMavBtZYDB9shH93";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = order.Id.ToString();
            request.Price = (order.Cart.TotalPrice * 1.18M).ToString();
            request.PaidPrice = (order.Cart.TotalPrice * 1.18M).ToString();
            request.Currency = C2C.Models.Currency.TRY.ToString();
            request.BasketId = order.CartId.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = "https://localhost:61656/Shop/CheckoutCompleted?orderId=" + order.Id.ToString();

            List<int> enabledInstallments = new List<int>();
            enabledInstallments.Add(2);
            enabledInstallments.Add(3);
            enabledInstallments.Add(6);
            enabledInstallments.Add(9);
            request.EnabledInstallments = enabledInstallments;


            List<BasketItem> basketItems = new List<BasketItem>();
            foreach (var item in order.Cart.CartItems)
            {
                BasketItem basketItem = new BasketItem();
                basketItem.Id = item.Id.ToString();
                basketItem.Name = item.Product.Name + " (" + item.Quantity.ToString() + " Adet)";
                basketItem.Category1 = "Tüm Ürünler";
                basketItem.Category2 = item.Product.Category.Name;
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItem.Price = (item.TotalPrice * 1.18M).ToString();
                basketItems.Add(basketItem);
            }

            request.BasketItems = basketItems;

            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
            if (string.IsNullOrEmpty(checkoutFormInitialize.PaymentPageUrl))
            {
                return RedirectToAction("Checkout", new { errorCode = checkoutFormInitialize.ErrorCode });
            }
            return Redirect(checkoutFormInitialize.PaymentPageUrl);
        }
        public IActionResult CheckoutCompleted(string orderId)
        {
            return View(model: orderId);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            controller.ViewBag.Categories = _context.Categories.ToList();

            // sepetteki ürün sayısını belirle
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }
            controller.ViewBag.CartItemCount = GetCart(owner).CartItems.Sum(c => c.Quantity);

            base.OnActionExecuting(context);
        }

        protected Cart GetCart(string owner)
        {
            Cart cart = _context.Carts.Include(i => i.CartItems).ThenInclude(t => t.Product).ThenInclude(k => k.Category).Where(c => c.Owner == owner).FirstOrDefault();
            if (cart == null)
            {
                cart = new Cart();
                cart.Owner = owner;
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }
            HttpContext.Session.SetString("CartId", cart.Id.ToString());
            return cart;
        }

        private Order GetOrder(string owner)
        {
            var cartId = GetCart(owner).Id;
            Order order = _context.Orders.Include(i => i.Cart).Where(o => o.CartId == cartId).FirstOrDefault();
            if (order == null)
            {
                order = new Order();
                order.CartId = Convert.ToString(HttpContext.Session.GetString("CartId"));
                order.OrderStatus = OrderStatus.Dispatched;
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            return order;
        }
    }
}