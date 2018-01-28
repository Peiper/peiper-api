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
    }
}
