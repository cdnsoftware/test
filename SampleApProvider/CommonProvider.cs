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


namespace SampleApProvider
{
   public class CommonProvider : ICommon
    {
       private SampleApContext _context;
       public CommonProvider(SampleApContext context)
        {
            _context = context;
        }


       // Get All display formats for user
       public List<MasterDisplayAs> GetAllDisplayFormats(int id = 0)
        {
            try
            {
                if (id > 0)
                {
                    return _context.Displays.Where(x => x.Id == id).OrderByDescending(x => x.Id).ToList();
                }
                else
                {
                    return _context.Displays.OrderByDescending(x => x.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<MasterDisplayAs>();
            }
        }

    }
}
