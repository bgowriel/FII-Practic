using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using EstateWebManager.API.Dto;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using MediatR;
using EstateWebManager.Application.Commands;
using EstateWebManager.Application.Queries;

namespace EstateWebManager.API.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly ILogger<ImagesController> _logger;



        public ImagesController(IConfiguration configuration, IMediator mediator, ILogger<ImagesController> logger)
        {
            _configuration = configuration;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] AppDataModel appDataModel, int realEstateId)
        {
            string systemFileName = appDataModel.File.FileName;

            string blobStorageConnection = _configuration.GetValue<string>("BlobConnectionString");

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobStorageConnection);

            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(_configuration.GetValue<string>("BlobContainerName"));

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);

            await using (var data = appDataModel.File.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }

            await _mediator.Send(new InsertImage { FileName = systemFileName, ImageUri = new Uri(blockBlob.Uri.ToString()), RealEstateId = realEstateId });

            return Ok(new { fileUrl = blockBlob.Uri.ToString() });
        }

        [HttpGet]//Download
        public async Task<IActionResult> GetImage(string fileName)
        {
            CloudBlockBlob blockBlob;

            await using (var memoryStream = new MemoryStream())
            {
                string blobStorageConnection = _configuration.GetValue<string>("BlobConnectionString");

                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobStorageConnection);

                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(_configuration.GetValue<string>("BlobContainerName"));

                blockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);

                await blockBlob.DownloadToStreamAsync(memoryStream);
            }

            Stream blobStream = blockBlob.OpenReadAsync().Result;

            return File(blobStream, blockBlob.Properties.ContentType, blockBlob.Name);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var query = new GetImageById { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("real-estate")]
        public async Task<IActionResult> GetImagesByRealEstateId([FromQuery] int realEstateId)
        {
            var query = new GetImagesByRealEstateId { RealEstateId = realEstateId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();
            
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage(string fileName)
        {
            string blobStorageConnection = _configuration.GetValue<string>("BlobConnectionString");

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobStorageConnection);

            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(_configuration.GetValue<string>("BlobContainerName"));

            var blob = cloudBlobContainer.GetBlobReference(fileName);

            await blob.DeleteIfExistsAsync();

            return Ok("File deleted");
        }
    }
}
