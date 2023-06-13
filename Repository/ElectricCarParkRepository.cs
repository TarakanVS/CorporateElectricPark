using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class ElectricCarParkRepository : IRepository
    {
        private readonly ElectricParkContext _context;
        private readonly IMapper _mapper; 
        public ElectricCarParkRepository(ElectricParkContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TEntity> DeleteAsync<TEntity>(Guid id)
            where TEntity : BaseEntity
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

        public async Task<TEntity> GetByPredicateAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : BaseEntity
        {
            var list = await _context.Set<TEntity>().Where(predicate).ToListAsync();

            return list.FirstOrDefault();
        }

        public async Task<List<TEntity>> GetAllAsync<TEntity>()
            where TEntity : BaseEntity
        {
            var result = await _context.Set<TEntity>().ToListAsync();
            return result;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(Guid id)
            where TEntity : BaseEntity
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<TEntity> InsertAsync<TEntity>(TEntity entity)
            where TEntity : BaseEntity
        {
            entity.Id = Guid.NewGuid();
            entity.AddedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync<TEntity>(TEntity newEntity)
            where TEntity : BaseEntity
        {
            newEntity.UpdatedDate = DateTime.Now;

            var entity = await _context.Set<TEntity>().Where(i => i.Id == newEntity.Id).FirstAsync();
            _mapper.Map(newEntity, entity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
