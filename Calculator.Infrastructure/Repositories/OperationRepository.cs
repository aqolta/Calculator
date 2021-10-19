using CSharpFunctionalExtensions;
using System.Linq;
using Calculator.Domain.Model;

namespace Calculator.Infrastructure.Repositories
{
    internal class OperationRepository : Repository<Operation>, IOperationRepository
    {
        public OperationRepository(CalculatorDBContext dbContext) : base(dbContext)
        {
        }
    }
}
