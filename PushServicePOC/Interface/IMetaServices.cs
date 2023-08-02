using PushServicePOC.Data.Entity;

namespace PushServicePOC.Interface
{
    /// <summary>
    ///     Meta Service Manager 
    /// </summary>
    public interface IMetaServices
    {
        public Task<HttpResponseMessage> CreateMetaCampaign(MetaCampaignModel metaCampaignObject);

        public Task<List<string>> GetAllMetaCampaign();
    }
}
