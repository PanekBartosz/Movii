namespace Movii.Data.Sql.DAO
{
    public class Order
    {
        public Order()
        {
            MovieOrders = new List<MovieOrder>();
        }
        
        public int OrderId { get; set; }
        public int MovieOrderId { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<MovieOrder> MovieOrders { get; set; }
    }
}

