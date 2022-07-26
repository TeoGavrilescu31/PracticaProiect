﻿using System.ComponentModel.DataAnnotations;

namespace PracticaProiect.Entities
{
    public class Category
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public bool? Deleted { get; set; }
    }
}
