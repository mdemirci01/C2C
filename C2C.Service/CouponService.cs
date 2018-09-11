using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C2C.Service
{
    public class CouponService : ICouponService
    {
        private readonly IRepository<Coupon> couponRepository;
        private readonly IUnitOfWork unitOfWork;
        public CouponService(IUnitOfWork unitOfWork, IRepository<Coupon> couponRepository)
        {
            this.couponRepository = couponRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Coupon entity)
        {
            couponRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await couponRepository.GetAsync(id);
            couponRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Coupon> GetAsync(string id)
        {
            return await couponRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Coupon>> GetAllAsync()
        {
            return await couponRepository.GetAllAsync();
        }

        public async Task InsertAsync(Coupon entity)
        {
            couponRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Coupon entity)
        {
            couponRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await couponRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface ICouponService
    {
        Task<IEnumerable<Coupon>> GetAllAsync();
        Task<Coupon> GetAsync(string id);
        Task InsertAsync(Coupon entity);
        Task UpdateAsync(Coupon entity);
        Task DeleteAsync(Coupon entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}
