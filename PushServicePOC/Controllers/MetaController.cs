using Microsoft.AspNetCore.Mvc;
using PushServicePOC.Data.Entity;
using PushServicePOC.Interface;

namespace PushServicePOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaController : ControllerBase
    {
        private readonly IMetaService _metaServices;
        private readonly MetaResponse metaResponse = new MetaResponse();

        /// <summary>
        ///      Initializes a new instance of Class
        /// </summary>
        /// <param name="metaServices">
        ///     Meta Service
        /// </param>
        public MetaController(IMetaService metaServices)
        {
            _metaServices = metaServices;
        }

        /// <summary>
        ///     Create Meta Campaign
        /// </summary>
        /// <param name="metaCampaignObject">
        ///    Campaign object to be post on meta server
        /// </param>
        /// <returns>
        ///     <c>not-null</c>
        /// </returns>
        [HttpPost("create-meta-campaign")]
        public ActionResult<HttpResponseMessage> PostMetaCampaign(
            MetaCampaignModel metaCampaignObject)
        {
            try
            {
                var response = _metaServices.CreateMetaCampaign(metaCampaignObject);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-campaign")]
        public ActionResult<MetaResponse> GetAllMetaCampaign()
        {
            try
            {
                var response = _metaServices.GetAllMetaCampaign();
                if (response.Result.Count > 0)
                {
                    metaResponse.status = true;
                    metaResponse.data = response.Result;
                    metaResponse.message = "total campaign:  " + response.Result.Count();
                }
                return Ok(metaResponse);
            }
            catch (Exception ex)
            {
                metaResponse.status = false;
                metaResponse.message = ex.Message;
                return BadRequest(metaResponse);
            }
        }
    }
}