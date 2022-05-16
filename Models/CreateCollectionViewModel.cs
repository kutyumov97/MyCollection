﻿namespace MyCollection.Models
{
    public class CreateCollectionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public CollectionTheme Theme { get; set; }
        public IFormFile? Image { get; set; }
        public string? AppUserId { get; set; }
        public string? FieldName1 { get; set; }
        public FieldType? TypeField1 { get; set; }
        public string? FieldName2 { get; set; }
        public FieldType? TypeField2 { get; set; }
        public string? FieldName3 { get; set; }
        public FieldType? TypeField3 { get; set; }
    }
}
