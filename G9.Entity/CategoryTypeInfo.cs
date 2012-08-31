using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G9.Entity
{
    public class CategoryTypeInfo
    {
        public int pk_ID { get; set; }
        public string s_CategoryName { get; set; }
        public int ParentID { get; set; }
        public bool IsContent { get; set; }
    }
}
