
using Microsoft.Extensions.DependencyInjection;
using Doctor.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.DalEF
{
    public static class ConfigurationExtension
    {
        public static void AddDalEF(this IServiceCollection services)
        {
            services.AddTransient<IPatientDetailsDal, PatientDetailsDaL>();
        }
    }
}
