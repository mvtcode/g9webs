using System.Collections.Generic;
using G9.Entity;

namespace G9.Service
{
    public interface IContact
    {
        int Insert(ContactInfo contact);
        int Delete(int id);
        int Update(ContactInfo contact);
        ContactInfo GetContactByID(int id);
        List<ContactInfo> GetListContact();

    }
}
