using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication1.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int PId { get; set; }
        [ForeignKey("PId")]
        [ValidateNever]
        public Product product { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter between range 1 to 1000")]
        public int count { get; set; }
        [NotMapped]
        public double price { get; set; }
    }
}
