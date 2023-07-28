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
       public MetaController(IMetaServices metaServices) { 
            _metaServices = metaServices;
             
        }

        [HttpPost("create-meta-campaign")]
        public ActionResult<HttpResponseMessage> PostMetaCampaign(MetaCampaignModel metaCampaignObject)
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
