using System.Threading.Tasks;
using Movii.IServices.Requests;

namespace Movii.IServices.Client
{
    public interface IClientService
    {
        Task<Movii.Domain.Client.Client> GetClientByClientId(int clientId);
        Task<Movii.Domain.Client.Client> GetClientByClientName(string clientName);
        Task<Movii.Domain.Client.Client> CreateClient(CreateClient createClient);
        Task EditClient(EditClient createClient, int clientId);
        Task UpdateClientAddress(UpdateClientAddress updateClientAddress, int clientId);
        Task RemoveClient(int clientId);
    }
}