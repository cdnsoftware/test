using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAp.Data;
using SampleAp.Data.Entities;


namespace SampleApCore.Interfaces
{
   public interface ICommon
    {
       // All common methods will collectively defined here
       List<MasterDisplayAs> GetAllDisplayFormats(int id = 0);


    }
}
