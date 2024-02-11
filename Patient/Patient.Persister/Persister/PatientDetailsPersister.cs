using DBContext.Entity;
using Patient.Dal;
using Patient.Persister.Model;
using Patient.Producer;
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
        private readonly PatientDetailsProducer _producerService;
        public PatientDetailsPersister(IPatientDetailsDal patientDetailsDal, PatientDetailsProducer _producerService)
        {
            this.patientDetailsDal = patientDetailsDal;
            this._producerService = _producerService;
        }

        public async Task<PostpatientDetails> InsertAsync(PostpatientDetails postpatientDetails)
        {

            PatientDetails patientDetails = new PatientDetails();
            patientDetails.Name = postpatientDetails.Name;
            patientDetails.Age = postpatientDetails.Age;
            patientDetails.Gender = postpatientDetails.Gender;
            patientDetails.Address = postpatientDetails.Address;
            patientDetails.MobileNo = postpatientDetails.MobileNo;
            patientDetailsDal.Insert(patientDetails);
            var message = JsonSerializer.Serialize(patientDetails);
            await _producerService.ProduceAsync("PostpatientDetails", message);
            return postpatientDetails;
        }
        public async Task<PutPatientDetails> UpdateAsync(PutPatientDetails postpatientDetails)
        {
            PatientDetails patientDetails = new PatientDetails();
            patientDetails.UHID = postpatientDetails.UHID;
            patientDetails.Name = postpatientDetails.Name;
            patientDetails.Age = postpatientDetails.Age;
            patientDetails.Gender = postpatientDetails.Gender;
            patientDetails.Address = postpatientDetails.Address;
            patientDetails.MobileNo = postpatientDetails.MobileNo;
            patientDetailsDal.Update(patientDetails); 
            var message = JsonSerializer.Serialize(patientDetails);
            await _producerService.ProduceAsync("PutpatientDetails", message);
            return postpatientDetails;
        }
        public async Task<PutPatientDetails> DeleteAsync(PutPatientDetails postpatientDetails)
        {
            PatientDetails patientDetails = new PatientDetails();
            patientDetails.UHID = postpatientDetails.UHID;
            patientDetails.Name = postpatientDetails.Name;
            patientDetails.Age = postpatientDetails.Age;
            patientDetails.Gender = postpatientDetails.Gender;
            patientDetails.Address = postpatientDetails.Address;
            patientDetails.MobileNo = postpatientDetails.MobileNo;
            patientDetailsDal.Delete(patientDetails);

            var message = JsonSerializer.Serialize(patientDetails);
            await _producerService.ProduceAsync("DeletepatientDetails", message);
            return postpatientDetails;
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
