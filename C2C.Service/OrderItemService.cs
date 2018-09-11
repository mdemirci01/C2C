using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace C2C.Service
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepository<OrderItem> orderItemRepository;
        private readonly IUnitOfWork unitOfWork;
        public OrderItemService(IUnitOfWork unitOfWork, IRepository<OrderItem> orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(OrderItem entity)
        {
        orderItemRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await orderItemRepository.GetAsync(id);
        orderItemRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<OrderItem> GetAsync(string id)
        {
            return await orderItemRepository.GetAsync(id);
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await orderItemRepository.GetAllAsync();
        }

        public async Task InsertAsync(OrderItem entity)
        {
            orderItemRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem entity)
        {
            orderItemRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await orderItemRepository.AnyAsync(a => a.Id == id);
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
