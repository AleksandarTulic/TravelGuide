﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Travel.API.Contracts;
using Travel.API.Entities.Context;

namespace Travel.API.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly TravelPlannerDbContext _dbContext;

        protected RepositoryBase(TravelPlannerDbContext dbContext,
            CancellationToken cancellationToken = default)
        {
            this._dbContext = dbContext;

        }

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.Set<T>().AddAsync(entity);

            return result.Entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Remove(entity);

            await Task.CompletedTask;
        }

        public async Task<IList<T>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        //Expression - linq
        public async Task<T?> GetByConditionAsync(Expression<Func<T, bool>> condition,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().Where(condition).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> UpdateAsync(int Id, T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Update(entity);
            return await Task.FromResult(entity);
        }
    }
}
