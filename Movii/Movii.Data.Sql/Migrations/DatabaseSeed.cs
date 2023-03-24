
using Movii.Data.Sql.DAO;

namespace Movii.Data.Sql.Migrations
{
    public class DatabaseSeed
     {
         private readonly MoviiDbContext _context;
         public DatabaseSeed(MoviiDbContext context)
         {
             _context = context;
         }
         
         //method responsible for populating the created database with test data
         //the order of calling is unfortunately important, as it is not possible to create a record
         //in the database without knowing the foreign key value
         //this is why you should start by completing the tables that have no foreign keys
         //--OFFTOP
         //the opposite is true for manually deleting tables with completed data in the database
         //start with tables that have foreign keys and end with tables that 
         //do not have
         public void Seed()
         {
            //regions allow code to be collapsed in the IDE
             //are not good practice, code in a class/method should not need to be collapsed
             //I have used them out of laziness this should not be the case
             
             #region CreateClients
             var clientList = BuildClientList();
             _context.Client.AddRange(clientList);
             _context.SaveChanges();
             #endregion
             
             #region CreateAuthors
             var authorList = BuildAuthorList();
             _context.Author.AddRange(authorList);
             _context.SaveChanges();
             #endregion
             
             #region CreateStorages
             var storageList = BuildStorageList();
             _context.Storage.AddRange(storageList);
             _context.SaveChanges();
             #endregion
             
             #region CreateMovies
             var movieList = BuildMovieList();
             _context.Movie.AddRange(movieList);
             _context.SaveChanges();
             #endregion

             #region CreateOrders
             var orderList = BuildOrderList(clientList);
             _context.Order.AddRange(orderList);
             _context.SaveChanges();
             #endregion
             
             #region CreateMovieOrders
             var movieOrderList = BuildMovieOrderList(orderList,movieList);
             _context.MovieOrder.AddRange(movieOrderList);
             _context.SaveChanges();
             #endregion

         }
    
         private IEnumerable<DAO.Client> BuildClientList()
         {
             var clientList = new List<DAO.Client>();
             var client = new DAO.Client()
             {
                 ClientName = "Bartosz",
                 ClientLastName = "Panek",
                 BirthDate = new DateTime(2000, 11, 20),
                 Gender = "Male",
                 ClientHistory = "Dunkierka - 20.03.2022,Kogiel Mogiel 4 - 27.03.2022",
                 ClientAddress = "Opole ul.Ozimska 99"
             };
             clientList.Add(client);
    
             var client2 = new DAO.Client()
             {
                 ClientName = "Anna",
                 ClientLastName = "Nowak",
                 BirthDate = new DateTime(1994, 1, 24),
                 Gender = "Female",
                 ClientHistory = "Mroczny Rycerz - 11.03.2022,Iron Man- 22.03.2022",
                 ClientAddress = "Opole ul.Pruszkowska 22"
             };
             clientList.Add(client2);
             
             for (int i = 3; i <= 20; i++)
             {
                 var client3 = new DAO.Client
                 {
                     ClientName = "client" + i,
                     ClientLastName = "lastname" + i,
                     BirthDate = new DateTime(1994, 1, 24),
                     Gender = i % 2 == 0 ? "Female" : "Male",
                     ClientHistory = "Mroczny Rycerz - 11.03.2022,Iron Man- 22.03.2022",
                     ClientAddress = "Opole ul.Pruszkowska" + i
                 };
                 clientList.Add(client3);
             }
    
             return clientList;
         }
    
         private IEnumerable<Storage> BuildStorageList()
         {
             var storageList = new List<Storage>
             {
                 new Storage
                 {
                     Quantity = 4,
                     DepartmentId = 1,
                     PlaceId = 4
                 },
                 new Storage
                 {
                     Quantity = 10,
                     DepartmentId = 1,
                     PlaceId = 1
                 },
                 new Storage
                 {
                     Quantity = 8,
                     DepartmentId = 1,
                     PlaceId = 2
                 },
                 new Storage
                 {
                     Quantity = 9,
                     DepartmentId = 1,
                     PlaceId = 3
                 },
                 new Storage
                 {
                     Quantity = 7,
                     DepartmentId = 2,
                     PlaceId = 1
                 },
                 new Storage
                 {
                     Quantity = 6,
                     DepartmentId = 2,
                     PlaceId = 2
                 },
                 new Storage
                 {
                     Quantity = 5,
                     DepartmentId = 2,
                     PlaceId = 3
                 }
             };
             return storageList;
         }
         
         private IEnumerable<Author> BuildAuthorList()
         {
             var authorList = new List<Author>
             {
                 new Author
                 {
                     AuthorName = "Bart",
                     AuthorLastName = "Collins",
                     AuthorOrigin = "USA",
                     AuthorPublications = "1.Avengers 2.Film",
                     BirthDate = new DateTime(1970, 6, 7)
                 },
                 new Author
                 {
                     AuthorName = "Phill",
                     AuthorLastName = "Noway",
                     AuthorOrigin = "USA",
                     AuthorPublications = "1.Batman 2.Film",
                     BirthDate = new DateTime(1970, 6, 7)
                 },
                 new Author
                 {
                     AuthorName = "Cody",
                     AuthorLastName = "Bard",
                     AuthorOrigin = "Polska",
                     AuthorPublications = "1.Najmro 2.Film",
                     BirthDate = new DateTime(1970, 6, 7)
                 },
                 new Author
                 {
                     AuthorName = "Quantino",
                     AuthorLastName = "Tarantula",
                     AuthorOrigin = "USA",
                     AuthorPublications = "1.CODA 2.Film",
                     BirthDate = new DateTime(1970, 6, 7)
                 },
                 new Author
                 {
                     AuthorName = "Anna",
                     AuthorLastName = "Posky",
                     AuthorOrigin = "Szwecja",
                     AuthorPublications = "1.Diuna 2.Film",
                     BirthDate = new DateTime(1970, 6, 7)
                 },
                 new Author
                 {
                     AuthorName = "David",
                     AuthorLastName = "Boateng",
                     AuthorOrigin = "USA",
                     AuthorPublications = "1.Men 2.Film",
                     BirthDate = new DateTime(1970, 6, 7)
                 },
                 new Author
                 {
                     AuthorName = "Robert",
                     AuthorLastName = "Holy",
                     AuthorOrigin = "USA",
                     AuthorPublications = "1.Kot w butach 2.Film",
                     BirthDate = new DateTime(1970, 6, 7)
                 },
                 new Author
                 {
                     AuthorName = "Bratt",
                     AuthorLastName = "Cuper",
                     AuthorOrigin = "USA",
                     AuthorPublications = "1.Bańka 2.Film",
                     BirthDate = new DateTime(1970, 6, 7)
                 },
                 new Author
                 {
                     AuthorName = "Dennis",
                     AuthorLastName = "Rocko",
                     AuthorOrigin = "USA",
                     AuthorPublications = "1.Memory 2.Film",
                     BirthDate = new DateTime(1970, 6, 7)
                 },
                 new Author
                 {
                     AuthorName = "David",
                     AuthorLastName = "Collins",
                     AuthorOrigin = "USA",
                     AuthorPublications = "1.Bella 2.Film",
                     BirthDate = new DateTime(1970, 6, 7)
                 },
                 new Author
                 {
                     AuthorName = "Van",
                     AuthorLastName = "Persie",
                     AuthorOrigin = "USA",
                     AuthorPublications = "1.Dual 2.Film",
                     BirthDate = new DateTime(1970, 6, 7)
                 },
             };
             return authorList;
         }

         private IEnumerable<Movie> BuildMovieList()
         {
             var movieList = new List<Movie>
             {
                 new Movie
                 {
                     AuthorId = 1,
                     StorageId = 1,
                     MovieName = "Avengers",
                     MovieDate = new DateTime(2007, 6, 7),
                     MovieRate = 4.5,
                     MovieCountryOfOrigin = "USA"
                 },
                 new Movie
                 {
                     AuthorId = 4,
                     StorageId = 1,
                     MovieName = "CODA",
                     MovieDate = new DateTime(2021, 2, 10),
                     MovieRate = 4.1,
                     MovieCountryOfOrigin = "USA"
                 },
                 new Movie
                 {
                     AuthorId = 2,
                     StorageId = 1,
                     MovieName = "Batman",
                     MovieDate = new DateTime(2022, 3, 7),
                     MovieRate = 4.9,
                     MovieCountryOfOrigin = "USA"
                 },
                 new Movie
                 {
                     AuthorId = 3,
                     StorageId = 1,
                     MovieName = "Najmro",
                     MovieDate = new DateTime(2022, 3, 7),
                     MovieRate = 4.2,
                     MovieCountryOfOrigin = "Polska"
                 },
                 new Movie
                 {
                     AuthorId = 5,
                     StorageId = 1,
                     MovieName = "Diuna",
                     MovieDate = new DateTime(2022, 1, 3),
                     MovieRate = 5,
                     MovieCountryOfOrigin = "USA"
                 },
                 new Movie
                 {
                     AuthorId = 7,
                     StorageId = 1,
                     MovieName = "Kot w butach",
                     MovieDate = new DateTime(2008, 9, 17),
                     MovieRate = 3.9,
                     MovieCountryOfOrigin = "USA"
                 },
                 new Movie
                 {
                     AuthorId = 6,
                     StorageId = 1,
                     MovieName = "Men",
                     MovieDate = new DateTime(1994, 6, 7),
                     MovieRate = 4.1,
                     MovieCountryOfOrigin = "USA"
                 },
                 new Movie
                 {
                     AuthorId = 9,
                     StorageId = 1,
                     MovieName = "Memory",
                     MovieDate = new DateTime(2020, 6, 7),
                     MovieRate = 3.6,
                     MovieCountryOfOrigin = "Szwecja"
                 },
                 new Movie
                 {
                     AuthorId = 8,
                     StorageId = 1,
                     MovieName = "Bańka",
                     MovieDate = new DateTime(1999, 3, 7),
                     MovieRate = 4.7,
                     MovieCountryOfOrigin = "USA"
                 },
                 new Movie
                 {
                     AuthorId = 11,
                     StorageId = 1,
                     MovieName = "Dual",
                     MovieDate = new DateTime(2022, 6, 7),
                     MovieRate = 3.2,
                     MovieCountryOfOrigin = "USA"
                 },
                 new Movie
                 {
                     AuthorId = 10,
                     StorageId = 1,
                     MovieName = "Belle",
                     MovieDate = new DateTime(2006, 6, 7),
                     MovieRate = 4.9,
                     MovieCountryOfOrigin = "USA"
                 }
             };
             return movieList;
         }
         
         private IEnumerable<Order> BuildOrderList(IEnumerable<DAO.Client> clientList)
         {
             var orderList = new List<Order>();
    
             var rand = new Random();
             var clientCount = clientList.ToList().Count;
             var j = 10;
             for (int i = 1; i <= 10; i++)
             {
                 orderList.Add(new Order
                 {
                     MovieOrderId = j,
                     ClientId = clientList.ToList()[rand.Next(clientCount)].ClientId
                 });
                 j--;
             }
             return orderList;
         }

         private IEnumerable<MovieOrder> BuildMovieOrderList(
             IEnumerable<Order> orderList, 
             IEnumerable<Movie> movieList)
         {
             var movieOrderList = new List<MovieOrder>();
    
             var r = new Random();
             var orderCount = orderList.ToList().Count;
             var movieCount = movieList.ToList().Count;
             for (int i = 1; i <= 10; i++)
             {
                 movieOrderList.Add(new MovieOrder
                 {
                     OrderId = orderList.ToList()[r.Next(orderCount)].OrderId,
                     MovieId = movieList.ToList()[r.Next(movieCount)].MovieId,
                 });
             }
             return movieOrderList;
         }
     }
}

