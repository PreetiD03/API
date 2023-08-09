using Google.Ads.GoogleAds.V14.Errors;
using Microsoft.AspNetCore.Mvc;
using PushServicePOC.Data.Entity;
using PushServicePOC.Interface;

namespace PushServicePOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleCampaignController : ControllerBase
    {
        private IGoogleCampaignManager _googleCampaignManager;
        public GoogleCampaignController(
            IGoogleCampaignManager googleCampaignManager)
        {
            _googleCampaignManager = googleCampaignManager;

        }

        [HttpPost("create-google-campaign")]
        public ActionResult<GoogleCampaignsResponse> CreateGoogleCampaign(
            GoogleCampaignModal googleCampaignModal)
        {
            try
            {
                var result = _googleCampaignManager.CreateGoogleCampaigns(googleCampaignModal);
                return Ok(result);
            }
            catch (GoogleAdsException e)
            {
                Console.WriteLine("Failure:");
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"Failure: {e.Failure}");
                Console.WriteLine($"Request ID: {e.RequestId}");
                return BadRequest(e.Message);    
            }
        }

    }


}