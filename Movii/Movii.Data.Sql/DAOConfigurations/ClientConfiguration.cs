using Movii.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movii.Data.Sql.DAOConfigurations
{
    public class ClientConfiguration: IEntityTypeConfiguration<DAO.Client>
    {
        public void Configure(EntityTypeBuilder<DAO.Client> builder)
        {
            builder.Property(c => c.ClientName).IsRequired(); 
            builder.Property(c => c.ClientLastName).IsRequired(); 
            builder.Property(c => c.BirthDate).IsRequired(); 
            builder.Property(c => c.Gender).IsRequired(); 
            builder.Property(c => c.ClientHistory).IsRequired();
            builder.Property(c => c.ClientAddress).IsRequired();

            builder.ToTable("Client");
        }
    }

}