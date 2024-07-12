using Geometry.Domain.Triangles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geometry.Infrastructure.Configurations;

internal sealed class TriangleConfiguration : IEntityTypeConfiguration<Triangle>
{
    public void Configure(EntityTypeBuilder<Triangle> builder)
    {
        builder.ToTable("triangles");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.SideA)
            .HasConversion(sideA => sideA.Value, value => new Side(value));

        builder.Property(t => t.SideB)
            .HasConversion(sideB => sideB.Value, value => new Side(value));

        builder.Property(t => t.SideC)
            .HasConversion(sideC => sideC.Value, value => new Side(value));

        builder.Property(t => t.Height);
    }
}
