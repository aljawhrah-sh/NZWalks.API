using System;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
	public class UpdateRegionDTO
	{

        [Required]
        [MinLength(3, ErrorMessage = " the code has minimum length of 3 characters")]
        [MaxLength(3, ErrorMessage = "the code has maximum length of 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "the name has maximum length of 100 characters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }

    }
}

