using System;
using NZWalks.API.Data;
using NZWalks.API.Models.Domian;

namespace NZWalks.API.Repository
{
	public class ImageRepository : IImageRepository
	{
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly NZWalksDbContext dbContext;

        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZWalksDbContext dbContext)
		{
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
		}

        public async Task<Image> Upload(Image image)
        {
            //creating the file path
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.fileName}{image.fileExtention}");

            //upload image to local file path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.file.CopyToAsync(stream);

            //url file path which will look similar to the below example
            //https://localhost:1234/Images/image.jpg
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.fileName}{image.fileExtention}";
            image.filePath = urlFilePath;

            //add image to the database
            await dbContext.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;
        }
    }
}

