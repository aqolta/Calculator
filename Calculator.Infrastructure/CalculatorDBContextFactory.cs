using Microsoft.EntityFrameworkCore.Design;

namespace Calculator.Infrastructure
{
    /// <summary>
    /// Will be used by ef core migration tools only
    /// For eg: Add-Migration InitialCreate
    /// </summary>
    internal class CalculatorDBContextFactory : IDesignTimeDbContextFactory<CalculatorDBContext>
    {
        public CalculatorDBContext CreateDbContext(string[] args)
        {
            return new CalculatorDBContext("Server=localhost\\SQLEXPRESS;Database=Calculator;Trusted_Connection=True;MultipleActiveResultSets=True");
         }
    }
}
 
