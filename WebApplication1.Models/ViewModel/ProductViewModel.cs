using System.Collections.Generic;
using System.Web.WebPages.Html;

namespace WebApplication1.Models.ViewModel
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public IEnumerable<SelectListItem> categorylist { get;set; }
        public IEnumerable<SelectListItem> covertypelist { get; set; }
    }
}
