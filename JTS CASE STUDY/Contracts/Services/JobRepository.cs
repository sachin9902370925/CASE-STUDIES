using Contracts.JobRepository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    class JobRepository : IJobRepository
    {
        //public static List<Job> Jobs { get; set; }
        public List<jobbb> CreateJob(jobbb j)
        {
            throw new NotImplementedException();
        }

        public jobbb DeleteJob(int id)
        {
            throw new NotImplementedException();
        }

        public jobbb EditJob(int id, jobbb j)
        {
            throw new NotImplementedException();
        }

        public List<jobbb> GetAllJob()
        {
            throw new NotImplementedException();
        }

        public jobbb GetJob(int id)
        {
            throw new NotImplementedException();
        }
    }
}
