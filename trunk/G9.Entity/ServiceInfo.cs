using System;

namespace G9.Entity
{
    [Serializable]
    public class ServiceInfo
    {
        public int pk_Id { get; set; }
        public string s_ServiceName { get; set; }
        public string s_Description { get; set; }
    }
}
