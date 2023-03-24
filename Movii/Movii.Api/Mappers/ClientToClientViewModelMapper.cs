using Movii.Api.ViewModels;

namespace Movii.Api.Mappers
{
    public class ClientToClientViewModelMapper
    {
        public static ClientViewModel ClientToClientViewModel(Domain.Client.Client client)
        {
            var clientViewModel = new ClientViewModel
            {
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                ClientLastName = client.ClientLastName,
                Gender = client.Gender,
                BirthDate = client.BirthDate,
                ClientAddress = client.ClientAddress,
                ClientHistory = client.ClientHistory
                
            };
            return clientViewModel;
        }

    }
}