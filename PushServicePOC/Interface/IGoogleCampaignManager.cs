using PushServicePOC.Data.Entity;

namespace PushServicePOC.Interface
{
    public interface IGoogleCampaignManager
    {
        public Task<GoogleCampaignsResponse> CreateGoogleCampaigns(
            GoogleCampaignModal googleCampaignModal);
    }
}