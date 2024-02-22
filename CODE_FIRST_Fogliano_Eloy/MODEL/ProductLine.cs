using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class ProductLine
    {
        [Key]
        public string productLine { get; set; }
        public string TextDescription { get; set; }
        public string HtmlDescription { get; set; }
        public string Image { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
