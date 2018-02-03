using System;

namespace PeiperApi.Domain.Models.Deploy
{
    public enum BuildStatus
    {
        STARTED,
        FAILED,
        DONE
    }
    public class SiteBuild : Entity
    {
        public string Status { get; set; }
        public string Hash { get; set; }
        public string Message { get; set; }

        public SiteBuild()
        {
            
        }

        public SiteBuild(string hash, string message)
        {
            BuildDataSetup();
            Hash = hash;
            Message = message;
        }

        public void BuildDataSetup()
        {
            Created = DateTime.Now;
            Status = BuildStatus.STARTED.ToString();
        }
    }
}
