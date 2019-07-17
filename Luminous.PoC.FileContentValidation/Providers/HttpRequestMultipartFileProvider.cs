using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Luminous.PoC.FileContentValidation.Models;

namespace Luminous.PoC.FileContentValidation.Providers
{
    internal class HttpRequestMultipartFileProvider : IHttpRequestFileProvider
    {
        public Task<IEnumerable<FileData>> GetFiles(HttpRequestMessage request)
        {
            if (request.Content == null || !request.Content.IsMimeMultipartContent())
            {
                throw new ArgumentException("Request does not contain multipart content.", nameof(request));
            }

            return GetFilesInternal(request);
        }

        private async Task<IEnumerable<FileData>> GetFilesInternal(HttpRequestMessage request)
        {
            var multipartMemoryStreamProvider = new MultipartMemoryStreamProvider();

            await request.Content.ReadAsMultipartAsync(multipartMemoryStreamProvider);

            var fileTasks = multipartMemoryStreamProvider.Contents.Select(async (httpContent) => new FileData(
                httpContent.Headers.ContentDisposition.FileName.Trim('\"'),
                await httpContent.ReadAsStreamAsync(),
                httpContent.Headers.ContentType.ToString(),
                httpContent.Headers.ContentLength)
            ).ToList();

            return await Task.WhenAll(fileTasks);
        }
    }
}