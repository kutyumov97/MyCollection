using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyCollection.Models
{
    public class AppUser : IdentityUser
    {
        public virtual List<Collection> AppUserCollection { get; set; } = new List<Collection>();
        public virtual List<Item> AppUserItem { get; set; } = new List<Item>();
        public Status Status { get; set; }
        public string UserRole { get; set; }
    }

    public enum Status
    {
        Active = 0,
        Blocked = 1
    }
}
