using Microsoft.AspNetCore.Mvc;
using Patient.Persister.Model;
using Patient.Persister.Persister;
using Patient.Producer;
using System.Text.Json;

namespace PatientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDeatilsController : ControllerBase
    {
        private readonly PatientDetailsPersister _persister;
       
        public PatientDeatilsController(PatientDetailsPersister persister)
        {
            _persister = persister;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Details = _persister.GetDetails();

            return Ok(Details);
        }

        [HttpPost]
        public IActionResult Post(PostpatientDetails postpatientDetails)
        {
            var patientDetails = _persister.InsertAsync(postpatientDetails);
            
            return Ok(patientDetails);
        }

        [HttpPut]
        public IActionResult Put(PutPatientDetails postpatientDetails)
        {
            var patientDetails = _persister.UpdateAsync(postpatientDetails);

            return Ok(patientDetails);
        }
        [HttpDelete]
        public IActionResult Delete(PutPatientDetails postpatientDetails)
        {
            var patientDetails = _persister.DeleteAsync(postpatientDetails);

            return Ok(patientDetails);
        }
    }
}
