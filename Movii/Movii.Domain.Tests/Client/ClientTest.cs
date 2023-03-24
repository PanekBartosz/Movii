using System;
using Movii.Domain.DomainExceptions;
using Xunit;

namespace Movii.Domain.Tests.Client
{
    public class ClientTest
    {
        public ClientTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public void CreateClient_Returns_throws_InvalidBirthDateException()
        {
            Assert.Throws<InvalidBirthDateException>
            (() => new Domain.Client.Client(
                "Name", "LastName",
                DateTime.UtcNow.AddHours(1), "Male",
                "History", "Address"
                ));
        }
        
        [Fact]
        public void CreateClient_Returns_Correct_Response()
        {
            var client = new Domain.Client.Client( "Name", "LastName",
                DateTime.UtcNow, "Male", "History", "Address");
            
            Assert.Equal("Name", client.ClientName);
            Assert.Equal("LastName", client.ClientLastName);
            Assert.Equal("Male", client.Gender);
            Assert.Equal("History", client.ClientHistory);
            Assert.Equal("Address", client.ClientAddress);
        }

    }
}