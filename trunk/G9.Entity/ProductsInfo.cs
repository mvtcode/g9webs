using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G9.Entity
{
    [Serializable]
    public class ProductsInfo
    {
        public int pk_ID { get; set; }
        public string s_Name { get; set; }
        public string s_Description { get; set; }
        public double f_Price { get; set; }
        //public int fk_ProductID { get; set; }
        //public string s_ProductName { get; set; }
        public string s_Image { get; set; }
        public string s_Content { get; set; }
        public int SortField { get; set; }
        public bool Active { get; set; }
        public DateTime d_CreateDate { get; set; }
        //public string sPath { get; set; }
    }
}
