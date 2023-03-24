namespace Movii.Data.Sql.DAO
{
    public class Author
    {
        public Author()
        {
            Movies = new List<Movie>();
        }
        
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string AuthorOrigin { get; set; }
        public string AuthorPublications { get; set; }
        
        public virtual ICollection<Movie> Movies { get; set; }
    } 
}
