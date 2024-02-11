
using Microsoft.Extensions.DependencyInjection;
using Doctor.Dal;
using Patient.Persister.Persister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Persister.Model
{
    public static class ModelConfigurationExtension
    {
        public static void AddModel(this IServiceCollection services)
        {
            services.AddTransient<PostpatientDetails, PostpatientDetails>();
            services.AddTransient<PutPatientDetails, PutPatientDetails>();
        }
    }
}
