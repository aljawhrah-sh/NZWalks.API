using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.Models.Domian
{
	public class Image
	{
		public Guid Id { get; set; }

		[NotMapped]
		public IFormFile file { get; set; }

		public string fileName { get; set; }

		public string? fileDescription { get; set; }

		public string fileExtention { get; set; }

		public long fileSizeinBytes { get; set; }

		public string filePath { get; set; }

	}
}

