using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class MyRepositotyAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContexts dbContext;
        public MyRepositotyAsync(ApplicationDbContexts dbcontext) : base(dbcontext)
        {
            this.dbContext = dbcontext;
        }
    }
}
