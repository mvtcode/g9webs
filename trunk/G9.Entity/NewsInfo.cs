
using System;

namespace G9.Entity
{   
    [Serializable]
    public class NewsInfo
    {
        public int pk_Id { get; set; }
        public string s_Title { get; set; }
        public string s_Description { get; set; }
        public string s_Image { get; set; }
        public string s_Content { get; set; }
        public DateTime d_DateCreated { get; set; }
        public int fk_UserId { get; set; }
        public string s_FullName { get; set; }
        public int fk_CategoryId { get; set; }
        public string fk_CategoryName { get; set; }
        public int SortField { get; set; }
        public bool Active { get; set; }
    }
}
