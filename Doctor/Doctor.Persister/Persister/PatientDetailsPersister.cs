using DBContext.Entity;
using Doctor.Dal;
using Patient.Persister.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Patient.Persister.Persister
{
    public class PatientDetailsPersister
    {
        private readonly IPatientDetailsDal patientDetailsDal;
        public PatientDetailsPersister(IPatientDetailsDal patientDetailsDal)
        {
            this.patientDetailsDal = patientDetailsDal;
        }

        public Task<PutPatientDetails> InsertAsync(PutPatientDetails postpatientDetails)
        {

            PatientDetails patientDetails = new PatientDetails();
            patientDetails.UHID = postpatientDetails.UHID;
            patientDetails.Name = postpatientDetails.Name;
            patientDetails.Age = postpatientDetails.Age;
            patientDetails.Gender = postpatientDetails.Gender;
            patientDetails.Address = postpatientDetails.Address;
            patientDetails.MobileNo = postpatientDetails.MobileNo;
            patientDetailsDal.Insert(patientDetails);
            return Task.FromResult(postpatientDetails);
        }
        public Task<PutPatientDetails> UpdateAsync(PutPatientDetails postpatientDetails)
        {
            PatientDetails patientDetails = new PatientDetails();
            patientDetails.UHID = postpatientDetails.UHID;
            patientDetails.Name = postpatientDetails.Name;
            patientDetails.Age = postpatientDetails.Age;
            patientDetails.Gender = postpatientDetails.Gender;
            patientDetails.Address = postpatientDetails.Address;
            patientDetails.MobileNo = postpatientDetails.MobileNo;
            patientDetailsDal.Update(patientDetails); 
            return Task.FromResult(postpatientDetails);
        }
        public Task<PutPatientDetails> DeleteAsync(PutPatientDetails postpatientDetails)
        {
            PatientDetails patientDetails = new PatientDetails();
            patientDetails.UHID = postpatientDetails.UHID;
            patientDetails.Name = postpatientDetails.Name;
            patientDetails.Age = postpatientDetails.Age;
            patientDetails.Gender = postpatientDetails.Gender;
            patientDetails.Address = postpatientDetails.Address;
            patientDetails.MobileNo = postpatientDetails.MobileNo;
            patientDetailsDal.Delete(patientDetails);

            return Task.FromResult(postpatientDetails);
        }

        public List<PutPatientDetails> GetDetails()
        {
            List<PutPatientDetails> list = new List<PutPatientDetails>();
            foreach (var item in patientDetailsDal.FetchList())
            {
                PutPatientDetails patientDetails = new PutPatientDetails();
                patientDetails.UHID = item.UHID;
                patientDetails.Name = item.Name;
                patientDetails.Age = item.Age;
                patientDetails.Gender = item.Gender;
                patientDetails.Address = item.Address;
                patientDetails.MobileNo = item.MobileNo;
                list.Add(patientDetails);
            }
            return list;
        }
    }
}
