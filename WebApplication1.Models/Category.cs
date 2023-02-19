using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Range(1,100,ErrorMessage ="Order must be in between 1 and 100")]
        public int displayorder { get; set; }
        public DateTime createdDatetime { get; set; } = DateTime.Now;
    }
}
