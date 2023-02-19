using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication1.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  String Name { get; set; }
    }
}
