using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Persister.Model
{
    public class PutPatientDetails
    {
        public String? Name { get; set; }
        public Int32 Age { get; set; }
        public String? MobileNo { get; set; }
        public String? Gender { get; set; }
        public String? Address { get; set; }
        public Guid UHID { get; set; }
    }
}
