using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CutomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domian;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;
        

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }


        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation("GetAll regeions method was invoked.");

            //get data from database through the domain model 
            var regionsDomain = await regionRepository.GetAllAsync();

            //map domain models to the  DTO

            var regionsDto = mapper.Map<List<GetRegionDTO>>(regionsDomain);

            //logger shows the information of the invoked method
            logger.LogInformation($"finished getAll regions with data: {JsonSerializer.Serialize(regionsDto)}");
            
            //return the dto
            return Ok(regionsDto);
        }
            
        

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);

            //map from the domain model to the  DTO

            var regionsDto = mapper.Map<GetRegionDTO>(regionDomain);

            

            if (regionDomain == null)
            {
                return NotFound();
            }
                //return dto
                return Ok(regionsDto);
        }

        [HttpPost]
        [validateModelAttributes]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionDTO AddRegionDTO)
        {
            
                //map from dto to domain model
                var regionDomain = mapper.Map<Region>(AddRegionDTO);



                //use domain model to create a region in the db through the dbContext
                await regionRepository.CreateAsync(regionDomain);
                await dbContext.SaveChangesAsync();

                //map domain model back to dto

                var regionDto = mapper.Map<AddRegionDTO>(regionDomain);


                return Ok(regionDto);
            


        }

        [HttpPut]
        [Route("{id:Guid}")]
        [validateModelAttributes]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDTO updateRegionDTO)
        {
                //map from dto to domain model
                var regionDomain = mapper.Map<Region>(updateRegionDTO);

                regionDomain = await regionRepository.UpdateAsync(id, regionDomain);

                if (regionDomain == null)
                {
                    return NotFound();
                }

                //convert domain model to dto to show at output
                var regionDto = mapper.Map<UpdateRegionDTO>(regionDomain);



                return Ok(regionDto);
            


        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            
            var regionDomain = await regionRepository.DeleteAsync(id);

            //if not found
            if(regionDomain == null)
            {
                return NotFound();
            }

             
            
            return Ok();

        }


    }
}

