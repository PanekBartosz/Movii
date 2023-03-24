using System;

namespace Movii.Api.ViewModels
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string ClientHistory { get; set; }
        public string ClientAddress { get; set; }

    }
}