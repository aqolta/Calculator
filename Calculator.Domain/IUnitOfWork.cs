using System.Threading;
using System.Threading.Tasks;
using Calculator.Domain.Model;

namespace Calculator.Domain
{
    public interface IUnitOfWork
    {
        IOperationRepository OperationRepository { get; }

        int SaveChanges();
    }
}