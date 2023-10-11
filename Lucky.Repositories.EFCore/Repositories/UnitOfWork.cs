using Lucky.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucky.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Task<int> SaveChangeAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
