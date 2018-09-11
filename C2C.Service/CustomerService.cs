using C2C.Data;
using C2C.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace C2C.Service
{
    public class CustomerService:ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IUnitOfWork unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork, IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(Customer entity)
        {
            customerRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await customerRepository.GetAsync(id);
            customerRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Customer> GetAsync(string id)
        {
            return await customerRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await customerRepository.GetAllAsync();
        }

        public async Task InsertAsync(Customer entity)
        {
            customerRepository.Insert(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer entity)
        {
            customerRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(string id)
        {
            return await customerRepository.AnyAsync(a => a.Id == id);
        }
    }

    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetAsync(string id);
        Task InsertAsync(Customer entity);
        Task UpdateAsync(Customer entity);
        Task DeleteAsync(Customer entity);
        Task DeleteAsync(string id);
        Task<bool> AnyAsync(string id);
    }
}

