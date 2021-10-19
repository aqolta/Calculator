using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Calculator.Domain.Base.Model;

namespace Calculator.Domain.Base.Model
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : Entity, IAggregateRoot
    {
        void Add(TAggregateRoot entity);
        void Update(TAggregateRoot entity);
        Maybe<TAggregateRoot> GetById(object id);
        void Remove(TAggregateRoot entity);
        void RemoveRange(IEnumerable<TAggregateRoot> entities);
        IEnumerable<TAggregateRoot> GetAll();
    }
}