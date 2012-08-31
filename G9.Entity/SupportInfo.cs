using System;

namespace G9.Entity
{
    [Serializable]
    public class SupportInfo
    {
        public int pk_Id { get; set; }
        public string s_Name { get; set; }
        public string s_Email { get; set; }
        public string s_Skype { get; set; }
        public string s_Yahoo { get; set; }
        public string s_Mobile { get; set; }
    }
}