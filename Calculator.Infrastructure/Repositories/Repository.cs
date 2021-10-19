using System.Linq;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore; 
using  Entity = Calculator.Domain.Base.Model.Entity;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using Calculator.Domain.Base.Model;

namespace Calculator.Infrastructure.Repositories
{
    internal class Repository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : Entity
    {
        private readonly CalculatorDBContext dbContext;
        private DbSet<TAggregateRoot> entitySet;

        protected DbSet<TAggregateRoot> EntitySet
        {
            get { return entitySet ??= dbContext.Set<TAggregateRoot>(); }
        }
        public Repository(CalculatorDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(TAggregateRoot entity)
        {
            EntitySet.Add(entity);
        }

        public void Update(TAggregateRoot entity)
        {
            var entry = dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                EntitySet.Attach(entity);
                entry = dbContext.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public Maybe<TAggregateRoot> GetById(object id)
        {
            TAggregateRoot entity = EntitySet.Find(id);
            return entity != null ? Maybe<TAggregateRoot>.From(entity) : Maybe<TAggregateRoot>.None;
        }

        public IEnumerable<TAggregateRoot> GetAll()
        {
            return EntitySet.AsEnumerable();
        }

        public void Remove(TAggregateRoot entity)
        {
            EntitySet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TAggregateRoot> entities)
        {
            EntitySet.RemoveRange(entities);
        }

        public async Task<TAggregateRoot> GetByIdAsync(object id)
        {
            return await EntitySet.FindAsync(id).ConfigureAwait(false);
        }
        public async Task<IEnumerable<TAggregateRoot>> GetAllAsync()
        {
            return await EntitySet.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TAggregateRoot>> GetAllAsync<TProperty>(Expression<Func<TAggregateRoot, TProperty>> include)
        {
            IQueryable<TAggregateRoot> query = EntitySet.Include(include);
            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<TAggregateRoot> SingleOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return await EntitySet.SingleOrDefaultAsync(predicate).ConfigureAwait(false);
        }

    }
}
