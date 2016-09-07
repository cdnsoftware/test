using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAp.Data;
using SampleAp.Data.Entities;
using SampleApCore.ViewModels;

namespace SampleApCore.Interfaces
{
    public interface IContactUs
    {
        //List<IGrouping<string,vmContactList>>
        List<Contact> GetAllContacts(int id = 0);
        //List<vmContactList> GetAllNewTestContacts(int id = 0);
        List<IGrouping<string, vmContactList>> GetAllNewTestContacts(int id = 0);
        vmTransactionResult<Contact> CreateContact(Contact model);
        vmTransactionResult<bool> DeleteContact(int id);
    }
}
