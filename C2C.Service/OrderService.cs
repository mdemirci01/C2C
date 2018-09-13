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
        private readonly IRepository<Order> orderRepository;
        private readonly IUnitOfWork unitOfWork;
        public OrderService(IUnitOfWork unitOfWork, IRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Order entity)
        {
            orderRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await orderRepository.GetAsync(id);
            orderRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Order> GetAsync(string id)
        {
            return await orderRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await orderRepository.GetAllAsync();
        }

        public async Task InsertAsync(Order entity)
        {
            orderRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            orderRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await orderRepository.AnyAsync(a => a.Id == id);
        }

		Task<IEnumerable<Order>> IOrderService.GetAllAsync()
		{
			throw new NotImplementedException();
		}

		Task<Order> IOrderService.GetAsync(string id)
		{
			throw new NotImplementedException();
		}

		Task IOrderService.InsertAsync(Order entity)
		{
			throw new NotImplementedException();
		}

		Task IOrderService.UpdateAsync(Order entity)
		{
			throw new NotImplementedException();
		}

		Task IOrderService.DeleteAsync(Order entity)
		{
			throw new NotImplementedException();
		}

		Task IOrderService.DeleteAsync(string id)
		{
			throw new NotImplementedException();
		}

		Task<bool> IOrderService.AnyAsync(string id)
		{
			throw new NotImplementedException();
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
