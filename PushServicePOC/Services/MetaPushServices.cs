using PushServicePOC.Data.Entity;
using PushServicePOC.Interface;

namespace PushServicePOC.Services
{
    public class MetaPushServices : IMetaServices
    {
        private readonly string baseUrl = "https://graph.facebook.com/v16.0/act_674036544070348/campaigns";
        private readonly IConfigurationSection _configurationSection;
        private readonly HttpClient _client= new HttpClient();
        public MetaPushServices(IConfigurationSection configurationSection) {
            _configurationSection = _configurationSection.GetSection("APIAuthSetting");
        }
        public async Task<HttpResponseMessage> CreateMetaCampaign(MetaCampaignModel metaCampaignObject)
        {
            var requestData = new Dictionary<string, string>
            {
                { "name", metaCampaignObject.CampaignName },
                { "objective", metaCampaignObject.Objective },
                { "status", metaCampaignObject.Status },
                { "special_ad_categories",metaCampaignObject.SpecialAdCategories},
                { "smart_promotion_type", metaCampaignObject.SmartPromotionType },
                { "access_token", _configurationSection.GetSection("apiKey").Value}
            };

            var _request = new HttpRequestMessage()
            {
                RequestUri = new Uri(baseUrl),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(requestData)
            };

            var _response = await _client.SendAsync(_request);
            return _response;

        }

    }
}
