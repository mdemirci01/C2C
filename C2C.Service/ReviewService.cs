using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace C2C.Service
{
    public class ReviewService:IReviewService
    {
        private readonly IRepository<Review> reviewRepository;
        private readonly IUnitOfWork unitOfWork;
        public ReviewService(IUnitOfWork unitOfWork, IRepository<Review> reviewRepository)
        {
            this.reviewRepository = reviewRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Review entity)
        {
            reviewRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await reviewRepository.GetAsync(id);
            reviewRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Review> GetAsync(string id)
        {
            return await reviewRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await reviewRepository.GetAllAsync();
        }

        public async Task InsertAsync(Review entity)
        {
            reviewRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Review entity)
        {
            reviewRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await reviewRepository.AnyAsync(a => a.Id == id);
        }
    }
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review> GetAsync(string id);
        Task InsertAsync(Review entity);
        Task UpdateAsync(Review entity);
        Task DeleteAsync(Review entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}
