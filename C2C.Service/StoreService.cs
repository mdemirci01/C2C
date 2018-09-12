using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C2C.Service
{
    public class StoreService : IStoreService
    {
        private readonly IRepository<Store> storeRepository;
        private readonly IUnitOfWork unitOfWork;
        public StoreService(IUnitOfWork unitOfWork, IRepository<Store> storeRepository)
        {
            this.storeRepository = storeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Store entity)
        {
            storeRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await storeRepository.GetAsync(id);
            storeRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Store> GetAsync(string id)
        {
            return await storeRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            return await storeRepository.GetAllAsync();
        }

        public async Task InsertAsync(Store entity)
        {
            storeRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Store entity)
        {
            storeRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await storeRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface IStoreService
    {
        Task<IEnumerable<Store>> GetAllAsync();
        Task<Store> GetAsync(string id);
        Task InsertAsync(Store entity);
        Task UpdateAsync(Store entity);
        Task DeleteAsync(Store entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}
