using System;

namespace G9.Entity
{
    [Serializable]
    public class ContactInfo
    {
        public int pk_ID { get; set; }
        public string s_Name { get; set; }
        public string s_Email { get; set; }
        public string s_Address { get; set; }
        public string s_Company { get; set; }
        public string s_Phone { get; set; }
        public string  s_Fax { get; set; }
        public string s_Title { get; set; }
        public string s_Content { get; set; }
        public DateTime d_Create { get; set; }
    }
}
