namespace Ispit.Books.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
        //public ApplicationUser? ApplicationUser { get; set; }
        //public string? ApplicationUserId { get; set; }
    }

}
