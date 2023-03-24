using System;
using System.Collections.Generic;

namespace Movii.Data.Sql.DAO
{
  public class Client
  {
    public Client()
    {
      Orders = new List<Order>();
    }
    
    public int ClientId { get; set; }
    public string ClientName { get; set; }
    public string ClientLastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }
    public string ClientHistory { get; set; }
    public string ClientAddress { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
  }  
}

