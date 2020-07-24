using Rankipedia.Engine.Engines;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rankipedia.WebApi.Controllers.v1
{
    [RoutePrefix("api/v1/thirdDropDown")]
    public class ThirdDropDownController : ApiController
    {
        public readonly IDropDownEngine _engine;
        public ThirdDropDownController(IDropDownEngine engine)
        {
            _engine = engine;
        }

        [HttpGet]
        [Route("refId/{refId}")]
        public async Task<HttpResponseMessage> get(Guid refId)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _engine.GetThirdDropDown(refId));
            }
            catch (System.Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}