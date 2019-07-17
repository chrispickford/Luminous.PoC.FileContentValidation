using Luminous.PoC.FileContentValidation.Providers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Luminous.PoC.FileContentValidation.Controllers
{
    [Route]
    public class DefaultController : ApiController
    {
        private readonly IHttpRequestFileProvider _httpRequestFileProvider;

        public DefaultController(IHttpRequestFileProvider httpRequestFileProvider)
        {
            _httpRequestFileProvider = httpRequestFileProvider;
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostFile()
        {
            var files = await _httpRequestFileProvider.GetFiles(Request);

            return Ok(files);
        }
    }
}
