using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAp.Data;
using SampleAp.Data.Entities;

namespace SampleApCore.Interfaces
{
    public interface IContactUs
    {
        List<Contact> GetAllContacts(int id = 0);
        vmTransactionResult<Contact> CreateContact(Contact model);
        vmTransactionResult<bool> DeleteContact(int id);
    }
}
