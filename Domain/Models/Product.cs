using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
        [Range(1, 10000)]
        public double ListPrice { get; set; }
        [Range(1, 10000)]
        public double Price { get; set; }

        [Range(1, 10000)]
        public double Price50 { get; set; }

        [Range(1, 10000)]
        public double Price100 { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [Display(Name = "Category")]
        [ValidateNever]
        public Category? Category { get; set; } 

        [Required]
        public int CoverTypeId { get; set; }
        [ForeignKey("CoverTypeId")]
        [Display(Name = "Cover Type")]
        [ValidateNever]
        public CoverType? CoverType { get; set; }
    }
}
