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
        public Task<ICollection<FileData>> GetFiles(HttpRequestMessage request)
        {
            if (request.Content == null || !request.Content.IsMimeMultipartContent())
            {
                throw new ArgumentException("Request does not contain multipart content.", nameof(request));
            }

            return GetFilesInternal(request);
        }

        private async Task<ICollection<FileData>> GetFilesInternal(HttpRequestMessage request)
        {
            var multipartMemoryStreamProvider = new MultipartMemoryStreamProvider();

            await request.Content.ReadAsMultipartAsync(multipartMemoryStreamProvider);

            IList<FileData> files = multipartMemoryStreamProvider.Contents.Select(httpContent => new FileData
            {
                FileName = httpContent.Headers.ContentDisposition.FileName.Trim('\"'),
                MimeType = httpContent.Headers.ContentType.ToString(),
                SizeBytes = httpContent.Headers.ContentLength
            }).ToList();

            return files;
        }
    }
}