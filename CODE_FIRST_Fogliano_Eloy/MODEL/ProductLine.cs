using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODE_FIRST_Fogliano_Eloy.MODEL
{
    public class ProductLine
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string productLine { get; set; }
        [Column(TypeName = "varchar(4000)")]
        public string TextDescription { get; set; }
        [Column(TypeName = "mediumtext")]
        public string HtmlDescription { get; set; }
        [Column(TypeName = "mediumblob")]
        public string Image { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
