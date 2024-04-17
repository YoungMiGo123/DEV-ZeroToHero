using Microsoft.AspNetCore.Identity;

namespace BooksApi.Core.Entities
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool Deactivated { get; set; }
        public bool IsDeleted { get; set; } 
        public ICollection<UserBook> BorrowedBooks { get; set; }
    }
}
