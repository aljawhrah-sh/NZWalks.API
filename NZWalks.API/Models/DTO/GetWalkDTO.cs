using System;
using NZWalks.API.Models.Domian;

namespace NZWalks.API.Models.DTO
{
	public class GetWalkDTO
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthinKm { get; set; }
        public string? WalkImageUrl { get; set; }


        public GetDifficultyDTO Difficulty { get; set; }
        public GetRegionDTO Region { get; set; }


    }
}

