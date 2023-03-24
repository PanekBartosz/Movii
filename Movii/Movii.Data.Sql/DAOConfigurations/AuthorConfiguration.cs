using Movii.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movii.Data.Sql.DAOConfigurations
{
    public class AuthorConfiguration: IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(c => c.AuthorName).IsRequired(); 
            builder.Property(c => c.AuthorLastName).IsRequired(); 
            builder.Property(c => c.BirthDate).IsRequired(); 
            builder.Property(c => c.AuthorPublications).IsRequired(); 
            builder.Property(c => c.AuthorOrigin).IsRequired();

            builder.ToTable("Author");
        }
    }

}