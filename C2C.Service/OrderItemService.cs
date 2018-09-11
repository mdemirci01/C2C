using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepository<OrderItem> productRepository;
        private readonly IUnitOfWork unitOfWork;
        public OrderItemService(IUnitOfWork unitOfWork, IRepository<OrderItem> productRepository)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(OrderItem entity)
        {
            productRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await productRepository.GetAsync(id);
            productRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<OrderItem> GetAsync(string id)
        {
            return await productRepository.GetAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await productRepository.GetAllAsync();
        }

        public async Task InsertAsync(OrderItem entity)
        {
            productRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem entity)
        {
            productRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await productRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task<OrderItem> GetAsync(string id);
        Task InsertAsync(OrderItem entity);
        Task UpdateAsync(OrderItem entity);
        Task DeleteAsync(OrderItem entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}
