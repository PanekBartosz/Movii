namespace Movii.Data.Sql.DAO
{
   public class Movie
   {
       public int MovieId { get; set; }
       public int AuthorId { get; set; }
       public int StorageId { get; set; }
       public string MovieName { get; set; }
       public DateTime MovieDate { get; set; }
       public double MovieRate { get; set; }
       public string MovieCountryOfOrigin { get; set; } 
      
      public virtual ICollection<MovieOrder> MovieOrders { get; set; }
      public virtual Storage Storage { get; set; }
      public virtual Author Author { get; set; }
   } 
}

