using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.interfaces;
using Task.DAL.Context;
using Task.DAL.Entity;

namespace Task.BLL.Reposatiories
{
    public class GenaricReposatory<T> : IGenaricReposatory<T> where T : class
    {
        private readonly DbContextClinic _DbContext;
        public GenaricReposatory(DbContextClinic dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<int> Add(T item)
        {
            await _DbContext.Set<T>().AddAsync(item);
            return await _DbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(T item)
        {
            _DbContext.Set<T>().Remove(item);
            return await _DbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int id)

          => await _DbContext.Set<T>().FindAsync(id);


        public async Task<IEnumerable<T>> GetAll()

           => await _DbContext.Set<T>().ToListAsync();


        public async Task<int> Update(T item)
        {
            _DbContext.Set<T>().Update(item);
            return await _DbContext.SaveChangesAsync();
        }
    }
}