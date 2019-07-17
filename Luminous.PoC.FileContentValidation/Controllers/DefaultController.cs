using Luminous.PoC.FileContentValidation.Providers;
using Luminous.PoC.FileContentValidation.Validators;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Luminous.PoC.FileContentValidation.Controllers
{
    [Route]
    public sealed class DefaultController : ApiController
    {
        private readonly IHttpRequestFileProvider _httpRequestFileProvider;
        private readonly IFileValidator _fileValidator;

        public DefaultController(IHttpRequestFileProvider httpRequestFileProvider, IFileValidator fileValidator)
        {
            _httpRequestFileProvider = httpRequestFileProvider;
            _fileValidator = fileValidator;
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostFile()
        {
            var files = await _httpRequestFileProvider.GetFiles(Request);

            var validationResults = await _fileValidator.Validate(files);

            if (validationResults.Any(x => !x.IsValid))
            {
                return BadRequest();
            }

            return Ok(files);
        }
    }
}
