using System;

namespace PeiperApi.Domain.Models.Deploy
{
    public enum BuildStatus
    {
        STARTED,
        FAILED,
        DONE
    }
    public class BuildData : Entity
    {
        public string status { get; set; }
        public string hash { get; set; }
        public string message { get; set; }

        public BuildData()
        {
            id = 0;
            created = DateTime.Now;
            status = BuildStatus.STARTED.ToString();
        }
        
        public BuildData(string hash, string message)
        {
            this = BuildData();
            this.hash = hash;
            this.message = message;
        }
    }
}
