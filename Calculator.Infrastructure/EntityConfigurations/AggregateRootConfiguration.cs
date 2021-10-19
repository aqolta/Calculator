using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calculator.Domain.Base.Model;

namespace Calculator.Infrastructure.EntityConfigurations
{
    internal abstract class AggregateRootConfiguration<TAggregateRoot> : IEntityTypeConfiguration<TAggregateRoot>
                                                                       where TAggregateRoot : Entity, IAggregateRoot
    {
        public virtual void Configure(EntityTypeBuilder<TAggregateRoot> builder)
        {
            //Base Configuration
        }

    }
}