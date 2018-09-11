using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace C2C.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }
    }

    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
