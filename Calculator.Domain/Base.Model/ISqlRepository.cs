using System.Collections.Generic;

namespace Calculator.Domain.Base.Model
{
    public interface ISqlRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
    }
}