using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace C2C.Service
{
     public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Category entity)
        {
            categoryRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await categoryRepository.GetAsync(id);
            categoryRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Category> GetAsync(string id)
        {
            return await categoryRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await categoryRepository.GetAllAsync();
        }

        public async Task InsertAsync(Category entity)
        {
            categoryRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category entity)
        {
            categoryRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await categoryRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetAsync(string id);
        Task InsertAsync(Category entity);
        Task UpdateAsync(Category entity);
        Task DeleteAsync(Category entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}

