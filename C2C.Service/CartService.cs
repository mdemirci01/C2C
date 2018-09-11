using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace C2C.Service
{
   public  class CartService : ICartService
    {
        private readonly IRepository<Cart> cartRepository;
        private readonly IUnitOfWork unitOfWork;
        public CartService(IUnitOfWork unitOfWork, IRepository<Cart> cartRepository)
        {
            this.cartRepository = cartRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Cart entity)
        {
            cartRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await cartRepository.GetAsync(id);
            cartRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Cart> GetAsync(string id)
        {
            return await cartRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await cartRepository.GetAllAsync();
        }

        public async Task InsertAsync(Cart entity)
        {
            cartRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cart entity)
        {
            cartRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await cartRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetAllAsync();
        Task<Cart> GetAsync(string id);
        Task InsertAsync(Cart entity);
        Task UpdateAsync(Cart entity);
        Task DeleteAsync(Cart entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }

}
