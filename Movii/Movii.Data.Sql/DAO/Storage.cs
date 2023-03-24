namespace Movii.Data.Sql.DAO
{
    public class Storage
    {
        public Storage()
        {
            Movies = new List<Movie>();
        }
        
        public int StorageId { get; set; }
        public int Quantity { get; set; }
        public int DepartmentId { get; set; }
        public int PlaceId { get; set; }
        
        public virtual ICollection<Movie> Movies { get; set; }
    }
}

