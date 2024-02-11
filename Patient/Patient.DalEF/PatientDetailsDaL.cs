using DBContext;
using DBContext.Entity;
using Patient.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.DalEF
{
    public class PatientDetailsDaL : IPatientDetailsDal
    {
        private readonly PatientDBContext dbContext;

        public PatientDetailsDaL(PatientDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(PatientDetails patientDetails)
        {
            var query = (from data in dbContext.PatientDetails where data.UHID == patientDetails.UHID  select data).First();

            dbContext.Attach(query);
            dbContext.Remove(query);
            dbContext.SaveChanges();
        }

        public List<PatientDetails> FetchList()
        {
           return dbContext.PatientDetails.ToList();
        }

        public void Insert(PatientDetails patientDetails)
        {
            dbContext.PatientDetails.Add(patientDetails);
            dbContext.SaveChanges();
        }

        public void Update(PatientDetails patientDetails)
        {
            var query = (from data in dbContext.PatientDetails where data.UHID == patientDetails.UHID select data).First();
            patientDetails = query;
            dbContext.PatientDetails.Add(patientDetails);
            dbContext.SaveChanges();
        }
    }
}
