using C2C.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace C2C.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync(params string[] nav)
        {
            var query = entities.AsNoTracking().AsQueryable();
            foreach (var n in nav)
                query = query.Include(n);
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetManyAsync(Func<T, bool> where, Func<T, object> orderby, bool desc = false, params string[] nav)
        {
            var query = entities.AsNoTracking().AsQueryable();
            foreach (var n in nav)
                query = query.Include(n);
            query = query.Where(where).AsQueryable();
            if (desc == false)
            {
                query = query.OrderBy(orderby).AsQueryable();
            }
            else
            {
                query = query.OrderByDescending(orderby).AsQueryable();
            }
            return await query.ToListAsync();
        }
        public async Task<bool> AnyAsync(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return await entities.AnyAsync(where);
        }
        public async Task<T> GetAsync(string id, params string[] nav)
        {
            var query = entities.AsNoTracking().AsQueryable();
            foreach (var n in nav)
                query = query.Include(n);
            return await query.FirstOrDefaultAsync(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = httpContextAccessor.HttpContext.User.Identity.Name ?? "username";
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = httpContextAccessor.HttpContext.User.Identity.Name ?? "username";
            entity.IpAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = httpContextAccessor.HttpContext.User.Identity.Name ?? "username";
            entity.IpAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.Now;
            entity.DeletedBy = httpContextAccessor.HttpContext.User.Identity.Name ?? "username";
            entity.IpAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            context.Entry(entity).State = EntityState.Modified;
        }
        

        public IEnumerable<T> GetAll(params string[] nav)
        {
            var query = entities.AsNoTracking().AsQueryable();
            foreach (var n in nav)
                query = query.Include(n);
            return query.ToList();
        }

        public IEnumerable<T> GetMany(Func<T, bool> where, Func<T, object> orderby, bool desc = false, params string[] nav)
        {
            var query = entities.AsNoTracking().AsQueryable();
            foreach (var n in nav)
                query = query.Include(n);
            query = query.Where(where).AsQueryable();
            if (desc == false)
            {
                query = query.OrderBy(orderby).AsQueryable();
            }
            else
            {
                query = query.OrderByDescending(orderby).AsQueryable();
            }
            return query.ToList();
        }

        public T Get(string id, params string[] nav)
        {
            var query = entities.AsNoTracking().AsQueryable();
            foreach (var n in nav)
                query = query.Include(n);
            return query.FirstOrDefault(s => s.Id == id);
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            return entities.Any(where);
        }
    }

    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(params string[] nav);
        IEnumerable<T> GetAll(params string[] nav);
        Task<IEnumerable<T>> GetManyAsync(Func<T, bool> where, Func<T, object> orderby, bool desc = false, params string[] nav);
        IEnumerable<T> GetMany(Func<T, bool> where, Func<T, object> orderby, bool desc = false, params string[] nav);
        Task<T> GetAsync(string id, params string[] nav);
        T Get(string id, params string[] nav);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> AnyAsync(System.Linq.Expressions.Expression<Func<T, bool>> where);
        bool Any(System.Linq.Expressions.Expression<Func<T, bool>> where);
    }
}
