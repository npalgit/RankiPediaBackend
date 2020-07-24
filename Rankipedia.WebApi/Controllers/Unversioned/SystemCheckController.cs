using System.Web.Http;

namespace Rankipedia.WebApi.Controllers
{
    [Route("api/isHealthy")]
    public class SystemCheckController : ApiController
    {
        public bool Get()
        {
            return true;
        }
    }
}
