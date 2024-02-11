using Confluent.Kafka;
using Newtonsoft.Json;
using Patient.Persister.Model;
using Patient.Persister.Persister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientConsumer
{
    public class PatientDetailsHandler

    {

        private readonly PatientDetailsPersister patientDetailsPersister;
        public PatientDetailsHandler(PatientDetailsPersister patientDetailsPersister)
        {
            this.patientDetailsPersister = patientDetailsPersister;
        }
        public String Insert(String message)
        {
            PutPatientDetails putPatientDetails = new PutPatientDetails();
            putPatientDetails = JsonConvert.DeserializeObject<PutPatientDetails>(message);
            var patientDetails = patientDetailsPersister.InsertAsync(putPatientDetails);
            return patientDetails.Result.ToString();
        }
    }
}
