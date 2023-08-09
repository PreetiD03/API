namespace PushServicePOC.Data.Entity
{
    public class MetaResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<string> data { get; set; }
    }
}