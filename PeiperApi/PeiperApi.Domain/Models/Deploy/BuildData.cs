using System;

namespace PeiperApi.Domain.Models.Deploy
{
    public enum BuildStatus
    {
        QUEUED,
        STARTED,
        FAILED,
        DONE
    }
    public class BuildData : Entity
    {
        public string Status { get; set; }
        public string Hash { get; set; }
        public string Message { get; set; }

        public BuildData()
        {

        }

        public BuildData(string hash, string message)
        {
            BuildDataSetup();
            Hash = hash;
            Message = message;
        }

        public void BuildDataSetup()
        {
            Created = DateTime.Now;
            Status = BuildStatus.QUEUED.ToString();
        }
    }

    public class SiteBuild : BuildData { }
    public class ApiBuild : BuildData { }
}
