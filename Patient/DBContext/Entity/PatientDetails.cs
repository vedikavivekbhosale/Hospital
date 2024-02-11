using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext.Entity
{
    [Table("Patient")]
    
    public class PatientDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UHID")]
        public Guid UHID { get; set; }
        [Column("Name")]
        public String? Name { get; set; }
        [Column("Age")]
        public Int32 Age { get; set; }
        [Column("MobileNo")]
        public String? MobileNo { get; set; }
        [Column("Gender")]
        public String? Gender { get; set; }
        [Column("Address")]
        public String? Address { get; set; }
       

    }
}
