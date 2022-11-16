﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Mot_Denis_Lab_2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }
        //public string Author { get; set; }

        [Column(TypeName = "decimal(6, 2)"),
        Range(0.01, 500)]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }

        public Publisher? Publisher { get; set; }

        public int? AuthorID { get; set; }

        public Author? Author { get; set; }
        //[NotMapped]

       // public Borrowing? Borrowing { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
