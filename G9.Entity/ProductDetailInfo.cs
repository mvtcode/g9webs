using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G9.Entity
{
    public class ProductDetailInfo
    {
        public int id { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public string sTitle { get; set; }
        public string sContent { get; set; }
        public string sFile { get; set; }
        public int Sort { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
