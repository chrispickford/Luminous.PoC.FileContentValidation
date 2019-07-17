using Luminous.PoC.FileContentValidation.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Luminous.PoC.FileContentValidation.Providers
{
    public interface IHttpRequestFileProvider
    {
        Task<IEnumerable<FileData>> GetFiles(HttpRequestMessage request);
    }
}