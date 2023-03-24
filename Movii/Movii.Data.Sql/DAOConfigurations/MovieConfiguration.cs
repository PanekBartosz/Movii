using Movii.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movii.Data.Sql.DAOConfigurations
{
    public class MovieConfiguration: IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(c => c.AuthorId).IsRequired(); 
            builder.Property(c => c.StorageId).IsRequired(); 
            builder.Property(c => c.MovieName).IsRequired(); 
            builder.Property(c => c.MovieDate).IsRequired(); 
            builder.Property(c => c.MovieRate).IsRequired(); 
            builder.Property(c => c.MovieCountryOfOrigin).IsRequired();

            builder.HasOne(x=>x.Author)
                .WithMany(x=>x.Movies)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.AuthorId);
            builder.HasOne(x=>x.Storage)
                .WithMany(x=>x.Movies)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.StorageId);

            
            builder.ToTable("Movie");
        }
    }

}