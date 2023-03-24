using System;
using System.Threading.Tasks;
using Movii.Domain.DomainExceptions;
using Movii.IData.Client;
using Movii.IServices.Requests;
using Movii.IServices.Client;
using Movii.Services.Client;
using Moq;
using Xunit;

namespace Movii.Services.Tests.Client
{
    public class ClientServiceTest
    {
        private readonly IClientService _clientService;
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        
        public ClientServiceTest()
        {
            //Arrange
            _clientRepositoryMock = new Mock<IClientRepository>(); //Mock creating fake object interface "IClientR.."
            _clientService = new ClientService(_clientRepositoryMock.Object);
        }
        
        [Fact]
        public void CreateClient_Returns_throws_InvalidBirthDateException()
        {
            var client = new CreateClient
            {
                ClientName = "Name",
                ClientLastName = "LastName",
                BirthDate = DateTime.UtcNow.AddHours(1),
                Gender = "Male",
                ClientHistory = "History",
                ClientAddress = "Address",
            };
            //ThrowsAsync because CreateClient type is Task(it's asynchronic)
            Assert.ThrowsAsync<InvalidBirthDateException>(() => _clientService.CreateClient(client));
        }
        
        [Fact]
        public async Task CreateClient_Returns_Correct_Response()
        {
            var client = new CreateClient
            {
                ClientName = "Name",
                ClientLastName = "LastName",
                BirthDate = DateTime.UtcNow,
                Gender = "Male",
                ClientHistory = "History",
                ClientAddress = "Address",
            };
            
            int expectedResult = 0;
            _clientRepositoryMock.Setup(x => x.CreateClient
                (new Domain.Client.Client
                (client.ClientName, 
                    client.ClientLastName, 
                    client.BirthDate, 
                    client.Gender,
                    client.ClientHistory,
                    client.ClientAddress)))
                .Returns(Task.FromResult(expectedResult));
            
            var result = await _clientService.CreateClient(client);
            
            Assert.IsType<Domain.Client.Client>(result);
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.ClientId);
        }

    }
}