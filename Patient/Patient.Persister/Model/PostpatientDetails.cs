using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Persister.Model
{
    public class PostpatientDetails
    {
        public String? Name { get; set; }
        public Int32 Age { get; set; }
        public string? MobileNo { get; set; }
        public String? Gender { get; set; }
        public String? Address { get; set; }
    }
}
