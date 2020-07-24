using Rankipedia.Engine.Engines;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Rankipedia.WebApi.Controllers.v1
{
    [RoutePrefix("api/v1/randomStrings")]
    public class RandomStringController : ApiController
    {
        private readonly RandomStringEngine _engine;
        public RandomStringController(RandomStringEngine engine)
        {
            _engine = engine;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _engine.GetCodes());
            }
            catch (System.Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}