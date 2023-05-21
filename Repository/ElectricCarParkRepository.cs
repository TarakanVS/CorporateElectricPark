using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ElectricCarParkRepository <TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ElectricParkContext _context;
        public ElectricCarParkRepository(ElectricParkContext context)
        {
            _context = context;
        }

        public async Task<TEntity> DeleteAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return entity;
            }

            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            return result;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            entity.AddedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
