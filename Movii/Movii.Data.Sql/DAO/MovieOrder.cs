namespace Movii.Data.Sql.DAO
{
    public class MovieOrder
    {

        public int MovieOrderId { get; set; }
        public int OrderId { get; set; }
        public int? MovieId { get; set; }
        
        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }
    }
}

