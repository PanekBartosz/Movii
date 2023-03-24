using System;

namespace Movii.IServices.Requests
{
    public class EditClient
    {
        
        public string ClientName { get; set; }
        
        public string ClientLastName { get; set; }
        
        public string Gender { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public string ClientHistory { get; set; }
        
        public string ClientAddress { get; set; }

    }
}