using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            var getJob = jobData.Find(id);
            


            return View(getJob);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            

            if (ModelState.IsValid)
            {
                Job newJob = new Job
                {
                    
                    Name = newJobViewModel.Name,
                    Employer = jobData.Employers.Find(newJobViewModel.EmployerID)
                    /*Employer = new Employer {
                        ID = newJobViewModel.EmployerID,
                        Value = newJobViewModel.Employers.Where(e => e.Value == newJobViewModel.EmployerID.ToString())
                        .Select(e => e.Text).FirstOrDefault()
                    }
                    */,
                    Location = new Location 
                    {
                        ID = newJobViewModel.JobLocation,
                        Value = newJobViewModel.Locations.Where(l => l.Value == newJobViewModel.JobLocation.ToString())
                        .Select(l => l.Text).FirstOrDefault()
                    },
                    CoreCompetency = new CoreCompetency
                    { 
                        ID = newJobViewModel.JobCoreCompetency,
                        Value = newJobViewModel.CoreCompetencies.Where(c => c.Value == newJobViewModel.JobCoreCompetency.ToString())
                        .Select(c => c.Text).FirstOrDefault()
                    },
                    PositionType = new PositionType
                    {
                        ID = newJobViewModel.JobPositionType,
                        Value = newJobViewModel.PositionTypes.Where(p => p.Value == newJobViewModel.JobPositionType.ToString())
                        .Select(p => p.Text).FirstOrDefault()
                    }




                };
                jobData.Jobs.Add(newJob);
                var currentId = newJob.ID;
                return Redirect($"/Job?id={currentId}");
            }

            return View(newJobViewModel);
        }
    }
}
