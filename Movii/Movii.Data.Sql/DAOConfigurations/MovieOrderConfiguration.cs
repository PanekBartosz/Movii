using Movii.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movii.Data.Sql.DAOConfigurations
{
    public class MovieOrderConfiguration: IEntityTypeConfiguration<MovieOrder>
    {
        public void Configure(EntityTypeBuilder<MovieOrder> builder)
        {
            builder.Property(c => c.MovieId).IsRequired();    
            builder.Property(c => c.OrderId).IsRequired();
            builder.HasOne(x=>x.Movie)
                .WithMany(x=>x.MovieOrders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.MovieId);
            builder.HasOne(x=>x.Order)
                .WithMany(x=>x.MovieOrders)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.OrderId);
            
            builder.ToTable("MovieOrder");
        }
    }

}