using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,100,ErrorMessage ="Order must be in between 1 and 100")]
        public int PostalCode { get; set; }
        public int Phone { get; set; }
        public string StreetAdress { get; set; }

        public string City { get; set; }
        public string State { get; set; }

    }
}
