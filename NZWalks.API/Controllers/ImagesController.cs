using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CutomActionFilters;
using NZWalks.API.Models.Domian;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        private readonly IImageRepository imageRepository;
        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        //image upload
        [HttpPost]
        [Route("Upload")]
        [validateModelAttributes]
        public async Task<IActionResult> Upload([FromForm] ImageUploadDTO uploadRequest)
        {
            //send image to validation method
            ValidateFileUpload(uploadRequest);
                //use repository to upload image
                //convert from dto to domain model
                var uploadDomain = new Image
                {
                    file = uploadRequest.file,
                    fileDescription = uploadRequest.fileDescription,
                    fileExtention = Path.GetExtension(uploadRequest.file.FileName),
                    fileName = uploadRequest.fileName,
                    fileSizeinBytes = uploadRequest.file.Length
                };

            //use repository to upload the image
            await imageRepository.Upload(uploadDomain);
            return Ok(uploadDomain);


        }

        private void ValidateFileUpload(ImageUploadDTO uploadRequest)
        {
            var allowedExtentions = new string[] { ".png", ".jpg", ".jpeg" };

            //check if the image file is from a valid extention
            if (!allowedExtentions.Contains(Path.GetExtension(uploadRequest.file.FileName)))
            {
                ModelState.AddModelError("file", "unsupported file extention.");
            }

            //check image file length
            if(uploadRequest.file.Length > 10485760)
            {
                ModelState.AddModelError("file", "file size more than 10MB, please upload a smaller size image.");
            }
        }
    }
}

