using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts.JobRepository
{
    public interface IJobRepository
    {
        public List<jobbb> GetAllJob();
        public jobbb GetJob(int id);
        public List<jobbb> CreateJob(jobbb j);
        public jobbb EditJob(int id, jobbb j);
        public jobbb DeleteJob(int id);
    }
}
