using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C2C.Service
{
    public class ShippingService : IShippingService
    {
        private readonly IRepository<Shipping> shippingRepository;
        private readonly IUnitOfWork unitOfWork;
        public ShippingService(IUnitOfWork unitOfWork, IRepository<Shipping> shippingRepository)
        {
            this.shippingRepository = shippingRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Shipping entity)
        {
            shippingRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await shippingRepository.GetAsync(id);
            shippingRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Shipping> GetAsync(string id)
        {
            return await shippingRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Shipping>> GetAllAsync()
        {
            return await shippingRepository.GetAllAsync();
        }

        public async Task InsertAsync(Shipping entity)
        {
            shippingRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shipping entity)
        {
            shippingRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await shippingRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface IShippingService
    {
        Task<IEnumerable<Shipping>> GetAllAsync();
        Task<Shipping> GetAsync(string id);
        Task InsertAsync(Shipping entity);
        Task UpdateAsync(Shipping entity);
        Task DeleteAsync(Shipping entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}
