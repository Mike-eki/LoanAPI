﻿using LoanAPI.Context;
using LoanAPI.Context.IEntity;
using LoanAPI.Models.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LoanAPI.Models.Repositories
{
    public class RepositoryAsync<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly AplicationDbContext _context;
        public RepositoryAsync(AplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> EntitySet
        {
            get
            {
                return _context.Set<T>();
            }
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }
        public async Task<T> GetById(int? id)
        {
            return await EntitySet.FindAsync(id);
        }
        public async Task<T> Insert(T entity)
        {
            await EntitySet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(T entity)
        {
            //var matchedEntity = await EntitySet.FirstOrDefaultAsync(x => x.Id == entity.Id);

            //if(matchedEntity != null)
            //{
            ////_context.Entry(entity).State = EntityState.Modified;
            //}

             _context.Update(entity);
            await _context.SaveChangesAsync();


            //_context.Update(entity);
        }
        public async Task DeleteById(int id)
        {
            T entity = await EntitySet.FindAsync(id);
            EntitySet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}