using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace C2C.Service
{
    public class CartItemService :ICartItemService
    {
        private readonly IRepository<CartItem> cartItemRepository;
        private readonly IUnitOfWork unitOfWork;
        public CartItemService(IUnitOfWork unitOfWork, IRepository<CartItem> cartItemRepository)
        {
            this.cartItemRepository = cartItemRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(CartItem entity)
        {
            cartItemRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await cartItemRepository.GetAsync(id);
            cartItemRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<CartItem> GetAsync(string id)
        {
            return await cartItemRepository.GetAsync(id);
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return await cartItemRepository.GetAllAsync();
        }

        public async Task InsertAsync(CartItem entity)
        {
            cartItemRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(CartItem entity)
        {
            cartItemRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await cartItemRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface ICartItemService
    {
        Task<IEnumerable<CartItem>> GetAllAsync();
        Task<CartItem> GetAsync(string id);
        Task InsertAsync(CartItem entity);
        Task UpdateAsync(CartItem entity);
        Task DeleteAsync(CartItem entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}

