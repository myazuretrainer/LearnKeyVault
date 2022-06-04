using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnKeyVault.Controllers
{

    public class FileUploadController : Controller
    {
        private readonly AddConfig config;
        public FileUploadController(AddConfig config)
        {
            this.config = config;

        }
       
        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            var filePaths = new List<string>();
            foreach (var formfile in files)
            {
                filePaths.Add(formfile.FileName);
                await UploadBlob(formfile.OpenReadStream(), formfile.FileName);
            }


            return Ok(new { message = "File Upload", count = files.Count });
        }

        public async Task<bool> UploadBlob(Stream filestream, string filename)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(config.Key);

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(config.Containername);

            BlobClient blobClient = containerClient.GetBlobClient(filename);
            await blobClient.UploadAsync(filestream, true);

            return await Task.FromResult(true);
        }

    }
}
