﻿using Microsoft.AspNetCore.Identity;

namespace Ispit.Books.Models
{
    public class ApplicationUser : IdentityUser

    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}
