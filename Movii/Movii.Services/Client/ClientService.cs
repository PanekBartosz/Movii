using System.Threading.Tasks;
using Movii.IData.Client;
using Movii.IServices.Requests;
using Movii.IServices.Client;

namespace Movii.Services.Client
{
    public class ClientService: IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<Domain.Client.Client> GetClientByClientId(int clientId)
        {
            return _clientRepository.GetClient(clientId);
        }

        public Task<Domain.Client.Client> GetClientByClientName(string clientName)
        {
            return _clientRepository.GetClient(clientName);
        }

        public async Task<Domain.Client.Client> CreateClient(CreateClient createClient)
        {
            var client = new Domain.Client.Client(createClient.ClientName, createClient.ClientLastName,
                createClient.BirthDate, createClient.Gender, createClient.ClientHistory, createClient.ClientAddress);
            client.ClientId = await _clientRepository.CreateClient(client);
            return client;
        }

        public async Task EditClient(EditClient createClient, int clientId)
        {
            var client = await _clientRepository.GetClient(clientId);
            client.EditClient(createClient.ClientName, createClient.ClientLastName, createClient.BirthDate,
                createClient.Gender, createClient.ClientHistory, createClient.ClientAddress);
            await _clientRepository.EditClient(clientId, client);
        }
        
        public async Task UpdateClientAddress(UpdateClientAddress updateClientAddress, int clientId)
        {
            var client = await _clientRepository.GetClient(clientId);
            client.ClientAddress = updateClientAddress.ClientAddress;
            
            await _clientRepository.EditClient(clientId, client);
        }
        
        public async Task RemoveClient(int clientId)
        {
            await _clientRepository.RemoveClient(clientId);
        }
    }
    
}