using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAp.Data
{
    public class vmTransactionResult<T>
    {
        public int StatusCode { get; set; } // To recognize the transaction returnd result. Assuming 200 : Success | -0 : Failed
        public T Object { get; set; }
        public String Message { get; set; } // In case fail the error message to display to client
        
    }
}
