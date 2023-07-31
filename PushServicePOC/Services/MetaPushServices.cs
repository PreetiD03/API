﻿using PushServicePOC.Data.Entity;
using PushServicePOC.Interface;

namespace PushServicePOC.Services
{
    /// <summary>
    ///     Meta services that implement all services logic to get or set meta campaign data 
    /// </summary>
    public class MetaPushServices : IMetaServices
    {
        // The meta api endpoint to create campaign
        private readonly string baseUrl = "https://graph.facebook.com/v16.0/act_674036544070348/campaigns";

        /// <summary>
        ///     Represents a section of application configuration values
        /// </summary>
        private readonly IConfigurationSection _apiAuthSettings;

        /// <summary>
        ///     Represents a set of key/value application configuration properties
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        ///     HttpClient instance that applied to all requests executed
        /// </summary>
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        ///     Initializes a new instance of Class
        /// </summary>
        /// <param name="configuration">
        ///     Initializes a new instance of the configuration
        /// </param>
        public MetaPushServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiAuthSettings = _configuration.GetSection("APIAuthSettings");
        }

        /// <summary>
        ///    Creating campaign to meta server
        /// </summary>
        /// <param name="metaCampaignObject">
        ///     Campaign object 
        /// </param>
        /// <returns>
        ///    <c>not-null</c>
        /// </returns>
        public async Task<HttpResponseMessage> CreateMetaCampaign(
            MetaCampaignModel metaCampaignObject)
        {
            // create a dictionary to hold the request headers
            var requestData = new Dictionary<string, string>
            {
                { "name", metaCampaignObject?.CampaignName },
                { "objective", metaCampaignObject?.Objective },
                { "status", metaCampaignObject?.Status },
                { "special_ad_categories",metaCampaignObject?.SpecialAdCategories},
                { "smart_promotion_type", metaCampaignObject?.SmartPromotionType },
                { "access_token",_apiAuthSettings.GetSection("clientId").Value}
            };

            //create a new HttpRequestMessage object with the specified method, url, and body
            var _request = new HttpRequestMessage()
            {
                RequestUri = new Uri(baseUrl),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(requestData)
            };

            // make the API call using the SendAsync method of the HttpClient
            var _response = await _client.SendAsync(_request);
            return _response;
        }
    }
}
