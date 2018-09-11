using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C2C.Service
{
    public class ProductPhotoService : IProductPhotoService
    {
        private readonly IRepository<ProductPhoto> productPhotoRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProductPhotoService(IUnitOfWork unitOfWork, IRepository<ProductPhoto> productPhotoRepository)
        {
            this.productPhotoRepository = productPhotoRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(ProductPhoto entity)
        {
            productPhotoRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await productPhotoRepository.GetAsync(id);
            productPhotoRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<ProductPhoto> GetAsync(string id)
        {
            return await productPhotoRepository.GetAsync(id);
        }

        public async Task<IEnumerable<ProductPhoto>> GetAllAsync()
        {
            return await productPhotoRepository.GetAllAsync();
        }

        public async Task InsertAsync(ProductPhoto entity)
        {
            productPhotoRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductPhoto entity)
        {
            productPhotoRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await productPhotoRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface IProductPhotoService
    {
        Task<IEnumerable<ProductPhoto>> GetAllAsync();
        Task<ProductPhoto> GetAsync(string id);
        Task InsertAsync(ProductPhoto entity);
        Task UpdateAsync(ProductPhoto entity);
        Task DeleteAsync(ProductPhoto entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}
