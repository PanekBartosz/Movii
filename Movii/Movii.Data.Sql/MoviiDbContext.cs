using Movii.Data.Sql.DAO;
using Movii.Data.Sql.DAOConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Movii.Data.Sql
{
    //A class responsible for the configuration of the Entity Framework Core
    // Using an instance of the MoviiDbContext class, it is possible to perform
    //all database operations from database creation to database query etc.
    public class MoviiDbContext : DbContext
    {
        public MoviiDbContext(DbContextOptions<MoviiDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<DAO.Client> Client { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieOrder> MovieOrder { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        // Example of model/ency configuration via configuration classes from the DAOConfigurations folder
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new StorageConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new MovieOrderConfiguration());
        }
    }
}