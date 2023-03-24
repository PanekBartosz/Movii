using System.Threading.Tasks;
using Movii.IData.Client;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace Movii.Data.Sql.Client
{
    public class ClientRepository: IClientRepository
    {
        private readonly MoviiDbContext _context;
        private IClientRepository _clientRepositoryImplementation;

        public ClientRepository(MoviiDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Client.Client> GetClient(string clientName)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x=>x.ClientName == clientName);
            return new Domain.Client.Client(client.ClientId,
                client.ClientName,
                client.ClientLastName,
                client.BirthDate,
                client.Gender,
                client.ClientHistory,
                client.ClientAddress);
        }
        
        public async Task<Domain.Client.Client> GetClient(int clientId)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x=>x.ClientId == clientId);
            return new Domain.Client.Client(client.ClientId,
                client.ClientName,
                client.ClientLastName,
                client.BirthDate,
                client.Gender,
                client.ClientHistory,
                client.ClientAddress);
        }
        
        public async Task<int> CreateClient(Domain.Client.Client client)
        {
            var clientDAO =  new DAO.Client { 
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                ClientLastName = client.ClientLastName,
                BirthDate = client.BirthDate,
                Gender = client.Gender,
                ClientHistory = client.ClientHistory,
                ClientAddress = client.ClientAddress
            };
            await _context.AddAsync(clientDAO);
            await _context.SaveChangesAsync();
            return clientDAO.ClientId;
        }

        public async Task EditClient(int clientId, Domain.Client.Client client)
        {
            var editClient = await _context.Client.FirstOrDefaultAsync(x=>x.ClientId == client.ClientId);
            editClient.ClientName = client.ClientName;
            editClient.ClientLastName = client.ClientLastName;
            editClient.BirthDate = client.BirthDate;
            editClient.Gender = client.Gender;
            editClient.ClientHistory = client.ClientHistory;
            editClient.ClientAddress = client.ClientAddress;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveClient(int clientId)
        {
            var client = await _context.Client.FirstOrDefaultAsync(x => x.ClientId == clientId);

            if (client == null)
            {
                throw new Exception("Client not found");
            }
           _context.Order.RemoveRange(_context.Order.Where(x => x.ClientId == clientId));
           _context.MovieOrder.RemoveRange(_context.MovieOrder.Where(x => x.OrderId == clientId));
           _context.Client.Remove(client);
            await _context.SaveChangesAsync();
        }

    }

}