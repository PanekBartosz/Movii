using System;
using Movii.Domain.DomainExceptions;

namespace Movii.Domain.Client
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string ClientHistory { get; set; }
        public string ClientAddress { get; set; }

        public Client(int clientId, string clientName, string clientLastName, DateTime birthDate,
            string gender, string clientHistory, string clientAddress )
        {
            ClientId = clientId;
            ClientName = clientName;
            ClientLastName = clientLastName;
            BirthDate = birthDate;
            Gender = gender;
            ClientHistory = clientHistory;
            ClientAddress = clientAddress;

        }
        public Client(string clientName, string clientLastName, DateTime birthDate, string gender,
            string clientHistory, string clientAddress)
        {
            if (birthDate >= DateTime.UtcNow)
                throw new InvalidBirthDateException(birthDate);
            ClientName = clientName;
            ClientLastName = clientLastName;
            BirthDate = birthDate;
            Gender = gender;
            ClientHistory = clientHistory;
            ClientAddress = clientAddress;
        }
        
        public void EditClient(string clientName, string clientLastName, DateTime birthDate,
            string gender, string clientHistory, string clientAddress)
        {
            if (birthDate >= DateTime.UtcNow)
                throw new InvalidBirthDateException(birthDate);
            ClientName = clientName;
            ClientLastName = clientLastName;
            BirthDate = birthDate;
            Gender = gender;
            ClientHistory = clientHistory;
            ClientAddress = clientAddress;
        }

    }
}