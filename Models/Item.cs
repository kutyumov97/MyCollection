using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCollection.Models
{
    public enum SortState
    {
        NameAsc,
        NameDesc,
        TagAsc,
        TagDesc,
    }

    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string? Tags { get; set; }
       
        [ForeignKey("ItemCollection")]
        [Required]
        public int? CollectionId { get; set; }
        public virtual Collection ItemCollection { get; set; }
        
        [ForeignKey("ItemAppUser")]
        [Required]
        public string? AppUserId { get; set; }
        public AppUser ItemAppUser { get; set; }

        public int? AddInt1 { get; set; }
        public int? AddInt2 { get; set; }
        public int? AddInt3 { get; set; }
        public string? AddString1 { get; set; }
        public string? AddString2 { get; set; }
        public string? AddString3 { get; set; }
        public string? AddText1 { get; set; }
        public string? AddText2 { get; set; }
        public string? AddText3 { get; set; }
        public DateTime? AddTime1 { get; set; }
        public DateTime? AddTime2 { get; set; }
        public DateTime? AddTime3 { get; set; }
        public bool? AddBool1 { get; set; }
        public bool? AddBool2 { get; set; }
        public bool? AddBool3 { get; set; }
    }
}
