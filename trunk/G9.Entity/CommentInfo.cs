using System;

namespace G9.Entity
{
    [Serializable]
    public class CommentInfo
    {
        public int pk_Id { get; set; }
        public string s_CusName { get; set; }
        public string s_Comment { get; set; }
        public DateTime d_Date { get; set; }
        public  int sortField { get; set; }
        public bool Active { get; set; }
    }
}
