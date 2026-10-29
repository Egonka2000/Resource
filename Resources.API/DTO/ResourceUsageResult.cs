namespace Resources.API.DTO
{
    public class ResourceUsageResult
    {
        public string ResourceName { get; set; }
        public int UsagesLeft { get; set; }

        public ResourceUsageResult(string name, int usage)
        {
            this.ResourceName = name;
            this.UsagesLeft = usage;
        }
    }
}
