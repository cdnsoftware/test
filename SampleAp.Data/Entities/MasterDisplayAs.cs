using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAp.Data.Entities
{
   public class MasterDisplayAs
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string DisplayAs { get; set; }
    }
}
