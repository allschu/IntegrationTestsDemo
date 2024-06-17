namespace IntegrationTestsDemo.Domain
{
    public class Zone
    {
        public int ZonePk { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string Rights { get; set; }
        public bool Sys { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        
    }
}
