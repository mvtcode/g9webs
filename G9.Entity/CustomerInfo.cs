using System;

namespace G9.Entity
{
    [Serializable]
    public class CustomerInfo
    {
        public int pk_Id { get; set; }
        public string s_CustomerName { get; set; }
        public string s_Logo { get; set; }
        public string s_Address { get; set; }
        public string s_Mobile { get; set; }
        public string s_Email { get; set; }
        public string s_Homepage { get; set; }
        public DateTime d_CreateDate { get; set; }
    }
}
