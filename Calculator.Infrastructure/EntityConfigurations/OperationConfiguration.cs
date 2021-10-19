using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calculator.Domain.Model;

namespace Calculator.Infrastructure.EntityConfigurations
{
    internal class OperationConfiguration : AggregateRootConfiguration<Operation>, IEntityTypeConfiguration<Operation>
    {
        public override void Configure(EntityTypeBuilder<Operation> builder)
        {
            base.Configure(builder);
            builder.ToTable("operations");
            builder.HasKey(e => e.Id);
        }
    }
}
