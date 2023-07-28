using PushServicePOC.Data.Entity;

namespace PushServicePOC.Interface
{
    public interface IMetaServices
    {
        public Task<HttpResponseMessage> CreateMetaCampaign(MetaCampaignModel metaCampaignObject);
    }
}
