using System.Threading.Tasks;

namespace Movii.IData.Client
{
    public interface IClientRepository
    {
        Task<Movii.Domain.Client.Client> GetClient(string clientName);
        Task<Movii.Domain.Client.Client> GetClient(int clientId);
        Task<int> CreateClient(Movii.Domain.Client.Client client);
        Task EditClient(int clientId, Domain.Client.Client client);
        Task RemoveClient(int clientId);
    }
}