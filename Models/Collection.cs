using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCollection.Models
{
    public enum CollectionTheme
    {
        [Display(Name = "Stamps")]
        Stamps,
        [Display(Name = "Alcohol")]
        Alcohol,
        [Display(Name = "Сoins")]
        Сoins,
        [Display(Name = "Magnets")]
        Magnets
    }


    public enum FieldType
    {
        [Display(Name = "Numeric")]
        Numeric,
        [Display(Name = "String")]
        String,
        [Display(Name = "Text")]
        Text,
        [Display(Name = "Date")]
        Date,
        [Display(Name = "True/False")]
        TrueFalse
    }

    public class Collection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public CollectionTheme Theme { get; set; }     
        
        public virtual List<Item> CollectionItem { get; set; } = new List<Item>();       

        public virtual string? Image { get; set; }

        [ForeignKey("CollectionAppUser")]
        [Required]
        public string? AppUserId { get; set; }
        public AppUser? CollectionAppUser { get; set; }

        public string? FieldName1 { get; set; }
        public FieldType? TypeField1 { get; set; }
        public string? FieldName2 { get; set; }
        public FieldType? TypeField2 { get; set; }
        public string? FieldName3 { get; set; }
        public FieldType? TypeField3 { get; set; }
    }
}
