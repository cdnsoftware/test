using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAp.Data.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string Knickname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int MasterDisplayAsId { get; set; }


        public virtual MasterDisplayAs MasterDisplayAsList { get; set; }
    }
}
