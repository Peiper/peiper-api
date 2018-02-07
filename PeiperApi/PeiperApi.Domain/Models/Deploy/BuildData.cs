using System;

namespace PeiperApi.Domain.Models.Deploy
{
    public enum BuildStatus
    {
        QUEUED,
        STARTED,
        FAILED,
        SUCCESS
    }
    public class BuildData : Entity
    {
        public string Status { get; set; }
        public string Hash { get; set; }
        public string Message { get; set; }
        public string Version { get; set; }
    }

    public class SiteBuild : BuildData { }
    public class ApiBuild : BuildData { }
}
