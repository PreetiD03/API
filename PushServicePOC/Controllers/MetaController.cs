using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PushServicePOC.Data.Entity;
using PushServicePOC.Interface;

namespace PushServicePOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaController : ControllerBase
    {
        private readonly IMetaServices _metaServices;

        /// <summary>
        ///      Initializes a new instance of Class
        /// </summary>
        /// <param name="metaServices">
        ///     Meta Service
        /// </param>
        public MetaController(IMetaServices metaServices)
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
    }
}
