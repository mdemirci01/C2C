using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C2C.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Product entity)
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

        public async Task<Product> GetAsync(string id)
        {
            return await productRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await productRepository.GetAllAsync();
        }

        public async Task InsertAsync(Product entity)
        {
            productRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            productRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await productRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(string id);
        Task InsertAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DeleteAsync(Product entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}
