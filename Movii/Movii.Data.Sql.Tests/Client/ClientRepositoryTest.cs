using System;
using System.Threading.Tasks;
using Movii.Data.Sql.Client;
using Movii.IData.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Movii.Data.Sql.Tests.Client
{
    public class ClientRepositoryTest
    {
        private  MoviiDbContext _context;
        private  IClientRepository _clientRepository;

        public ClientRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MoviiDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;userid=root;pwd=passwd;port=3306;database=movii_db;");
            _context = new MoviiDbContext(optionsBuilder.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _clientRepository = new ClientRepository(_context);
        }
        
        [Fact]
        public async Task CreateClient_Returns_Correct_Response()
        {
            var client = new Domain.Client.Client("Name", "LastName", DateTime.UtcNow,
                "Male", "History", "Address");
            
            var clientId = await _clientRepository.CreateClient(client);
            
            var createdClient = await _context.Client.FirstOrDefaultAsync(x => x.ClientId == clientId);
            Assert.NotNull(createdClient);
            
            _context.Client.Remove(createdClient);
            await _context.SaveChangesAsync();
        }

    }
}