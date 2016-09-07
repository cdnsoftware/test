using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApCore;
using SampleApCore.Interfaces;
using SampleAp.Data;
using SampleAp.Data.Entities;
using System.Data;
using System.Data.Entity;
using SampleApCore.ViewModels;

namespace SampleApProvider
{
    public class ContactUsProvider : IContactUs
    {
        private SampleApContext _context;
      

        public ContactUsProvider(SampleApContext context)
        {
            _context = context;
        }

        public List<Contact> GetAllContacts(int id = 0)
        {
         //

            try
            {
                if (id > 0)
                {
                    return _context.Contacts.Where(x => x.Id == id).OrderByDescending(x => x.Id).ToList();
                }
                else
                {
                    return _context.Contacts.OrderByDescending(x => x.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Contact>();
            }
        }


        public List<IGrouping<string,vmContactList>> GetAllNewTestContacts(int id = 0)
        {
            List<vmContactList> modelLst = new List<vmContactList>();
            
            try
            {
                if (id > 0)
                {
                    _context.Contacts.Where(x => x.Id == id).ToList().ForEach(x => modelLst.Add(ConvertContactTovmContactList(x)));
                }
                else
                {
                    _context.Contacts.ToList().ForEach(x => modelLst.Add(ConvertContactTovmContactList(x))); //.OrderByDescending(x => x.Id).ToList();
                }

                return modelLst.OrderBy(x=>x.LastName).GroupBy(x=> x.LastName.Substring(0,1)).ToList();
            }
            catch (Exception ex)
            {
                return new List<IGrouping<string,vmContactList>>();
            }
        }
        private vmContactList ConvertContactTovmContactList(Contact model)
        {
            return new vmContactList()
            {
                 Id = model.Id,
                  FirstName = model.FirstName,
                   LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                     Knickname = model.Knickname,
                      PhoneNumber = model.PhoneNumber,
                      DisplayAs_ = model.MasterDisplayAsList.DisplayAs,
                       DisplayASSetting = GetDisplayNameBySetting(model)
            };
        }

        private string GetDisplayNameBySetting(Contact item)
        {
            var varDisplayAs = "";

            if (item.MasterDisplayAsId == (int)vmICommon.eDisplayAs.FirstLast)
            {
                varDisplayAs = item.FirstName + " " + item.LastName;
            }
            else if (item.MasterDisplayAsId == (int)vmICommon.eDisplayAs.LastFirst)
            {
                varDisplayAs = item.LastName + " " + item.FirstName;
            }
            else if (item.MasterDisplayAsId == (int)vmICommon.eDisplayAs.Knickname)
            {
                varDisplayAs = item.Knickname;
            }

            return varDisplayAs;
        }

        public vmTransactionResult<Contact> CreateContact(Contact model)
        {
            try
            {
                if (model.Id == 0)
                {
                    _context.Contacts.Add(model);
                    _context.SaveChanges();

                    return new vmTransactionResult<Contact>()
                    {
                        Message = "New Contact  " + model.FirstName + " " + model.LastName + " created successfully.",
                        Object = model,
                        StatusCode = 200
                    };
                }
                else
                {
                    var entry = _context.Entry<Contact>(model);
                    DbSet<Contact> dbSet = _context.Set<Contact>();
                    // Retreive the Id through reflection
                    var pkey = dbSet.Create().GetType().GetProperty("Id").GetValue(model);
                    if (entry.State == EntityState.Detached)
                    {
                        var set = _context.Set<Contact>();
                        Contact attachedEntity = set.Find(pkey);  // access the key
                        if (attachedEntity != null)
                        {
                            var attachedEntry = _context.Entry(attachedEntity);
                            attachedEntry.CurrentValues.SetValues(model);
                        }
                        else
                        {
                            entry.State = EntityState.Modified; // attach the entity
                        }
                    }
                    _context.SaveChanges();

                    return new vmTransactionResult<Contact>()
                    {
                        Message = "Contact " + model.FirstName +" "+ model.LastName + " updated successfully.",
                        Object = model,
                        StatusCode = 200
                    };
                }

                
            }
            catch (Exception ex)
            {
                return new vmTransactionResult<Contact>()
                {
                    Message = "Contact not created.try again!" + ex.Message,
                    Object = null,
                    StatusCode = -0
                };
            }
        }

        public vmTransactionResult<bool> DeleteContact(int id)
        {
            try
            {
                Contact model = _context.Contacts.Where(x => x.Id == id).FirstOrDefault();
                if (model != null)
                {
                    DbSet<Contact> dbSet = _context.Set<Contact>();
                    dbSet.Attach(model);
                    dbSet.Remove(model);
                    _context.SaveChanges();

                    return new vmTransactionResult<bool>()
                    {
                        Message = "Contact " + model.FirstName + " " + model.LastName + " deleted successfully.",
                        Object = true,
                        StatusCode = 200
                    };
                }
                else
                {
                    return new vmTransactionResult<bool>()
                    {
                        Message = "No record found to delete.",
                        Object = false,
                        StatusCode = -0
                    };
                }
            }
            catch (Exception ex)
            {
                return new vmTransactionResult<bool>()
                {
                    Message = "Contact not deleted. Something went wrong!",
                    Object = false,
                    StatusCode = -0
                };
            }
        }


    }
}
