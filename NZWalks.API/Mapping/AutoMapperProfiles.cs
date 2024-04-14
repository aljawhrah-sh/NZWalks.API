using System;
using AutoMapper;
using NZWalks.API.Models.Domian;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mapping
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{

			CreateMap<Region, GetRegionDTO>().ReverseMap();
			CreateMap<Region, AddRegionDTO>().ReverseMap();
			CreateMap<Region, UpdateRegionDTO>().ReverseMap();

			CreateMap<AddWalkDTO, Walk>().ReverseMap();
			CreateMap<GetWalkDTO, Walk>().ReverseMap();

			CreateMap<Difficulty, GetDifficultyDTO>().ReverseMap();

		}
	}
}

