using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechJobs.Models
{
    public class BaseJobViewModel
    {
        public JobFieldType Column { get; set; } = JobFieldType.All;

        public List<JobFieldType> Columns { get; set; }

        public string Title { get; set; } = "";

        public BaseJobViewModel()
        {
            Columns = new List<JobFieldType>();

            foreach (JobFieldType enumVal in Enum.GetValues(typeof(JobFieldType)))
            {
                Columns.Add(enumVal);
            }
        }



    }
}
