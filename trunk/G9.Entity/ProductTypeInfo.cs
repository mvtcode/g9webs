using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G9.Entity
{
    [Serializable]
    public class ProductTypeInfo
    {
        public int pk_ID { get; set; }
        public string s_ProductName { get; set; }
        public string Path { get; set; }
    }
}