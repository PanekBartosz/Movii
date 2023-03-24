using Movii.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movii.Data.Sql.DAOConfigurations
{
    public class StorageConfiguration: IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.Property(c => c.Quantity).IsRequired(); 
            builder.Property(c => c.DepartmentId).IsRequired(); 
            builder.Property(c => c.PlaceId).IsRequired();

            builder.HasMany(x => x.Movies)
                .WithOne(x=>x.Storage)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.StorageId);
            
            builder.ToTable("Storage");
        }
    }

}