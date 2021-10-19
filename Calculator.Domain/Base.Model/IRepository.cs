using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Calculator.Domain.Base.Model;

namespace Calculator.Domain.Base.Model
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        void Update(T entity);
        Maybe<T> GetById(object id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IEnumerable<T> GetAll();
    }
}