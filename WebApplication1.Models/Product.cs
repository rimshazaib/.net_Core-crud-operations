using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication1.Models
{
    public class Product
    {
       

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Discription { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1 , 1000)]
        public double Listprice { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price100 { get; set; }
       
        [Required]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        public int CoverTypeId { get; set; }
        [ValidateNever]
        public CoverType CoverType { get; set; }
        [ValidateNever]
        public string ImgUrl { get; set; }




    }
}
