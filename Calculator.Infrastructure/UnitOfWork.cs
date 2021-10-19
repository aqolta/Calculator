using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Calculator.Domain;
using Calculator.Domain.Model;
using Calculator.Infrastructure.Repositories;

namespace Calculator.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CalculatorDBContext dbContext;
        private readonly ILogger<UnitOfWork> logger;

        public UnitOfWork(IDatabaseConnectionString databaseConnectionString, ILogger<UnitOfWork> logger)
        {
            dbContext = new CalculatorDBContext(databaseConnectionString.ConnectionString);
            this.logger = logger;
        }

        private IOperationRepository operationRepository;

        public IOperationRepository OperationRepository => operationRepository ??= new OperationRepository(dbContext);

        public int SaveChanges()
        {
            logger.LogDebug($"Persisting repository changes to database with {dbContext.ChangeTracker.Entries().Count()} entries");
            var saveChangesResult = dbContext.SaveChanges();
            logger.LogDebug($"Persisted repository changes to database successfully. [{saveChangesResult} records changed]");

            return saveChangesResult;
        }
    }
}