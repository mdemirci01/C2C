using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace C2C.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> productRepository;
        private readonly IUnitOfWork unitOfWork;
        public OrderService(IUnitOfWork unitOfWork, IRepository<Order> productRepository)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Order entity)
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

        public async Task<Order> GetAsync(string id)
        {
            return await productRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await productRepository.GetAllAsync();
        }

        public async Task InsertAsync(Order entity)
        {
            productRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            productRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await productRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetAsync(string id);
        Task InsertAsync(Order entity);
        Task UpdateAsync(Order entity);
        Task DeleteAsync(Order entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}
