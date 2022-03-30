using CarProject.Domain.Entities.Abstract;
using CarProject.Domain.Interfaces;
using CarProject.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarProject.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Vehicle
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> dataSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            dataSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await dataSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await dataSet.AnyAsync(filter);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetbyIdAsync(id);
            entity.IsActive = false;
            await UpdateAsync(entity);
        }

        public async Task<List<TEntity>> GetAllActiveAsync()
        {
            return await dataSet.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await dataSet.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllInActiveAsync()
        {
            return await dataSet.Where(x => x.IsActive == false).ToListAsync();
        }

        public async Task<List<TEntity>> GetbyColorAsync(string color)
        {
            return await dataSet.Where(x => x.Color == color).ToListAsync();
        }

        public async Task<TEntity> GetbyIdAsync(int id)
        {
            var entity = await dataSet.SingleOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task RemoveFromDbAsync(int id)
        {
            var entity = await GetbyIdAsync(id);
            dataSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dataSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
