using Rankipedia.Engine.Engines;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rankipedia.WebApi.Controllers.v1
{
    [RoutePrefix("api/v1/firstDropDown")]
    public class FirstDropDownController : ApiController
    {
        private readonly IDropDownEngine _engine;
        public FirstDropDownController(IDropDownEngine engine)
        {
            _engine = engine;
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _engine.GetFirstDropDown());
            }
            catch (System.Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}