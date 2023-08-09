using Google.Ads.GoogleAds.V14.Services;

namespace PushServicePOC.Data.Entity
{
    public class GoogleCampaignsResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public MutateCampaignsResponse CampaignsResponseData { get; set; }
    }
}
