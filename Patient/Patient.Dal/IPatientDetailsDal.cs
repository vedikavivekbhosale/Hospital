using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBContext.Entity;

namespace Patient.Dal
{
    public interface IPatientDetailsDal
    {
        List<PatientDetails> FetchList();
        void Insert(PatientDetails fruits);
        void Update(PatientDetails fruits);
        void Delete(PatientDetails fruits);
    }
}
