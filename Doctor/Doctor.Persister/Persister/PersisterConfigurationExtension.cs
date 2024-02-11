
using Microsoft.Extensions.DependencyInjection;
using Doctor.Dal;
using Patient.Persister.Persister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Persister.Persister
{
    public static class PersisterConfigurationExtension
    {
        public static void AddPersister(this IServiceCollection services)
        {
            services.AddTransient<PatientDetailsPersister, PatientDetailsPersister>();
        }
    }
}
