using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CutomActionFilters;
using NZWalks.API.Models.Domian;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : Controller
    {

        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpPost]
        [validateModelAttributes]
        public async Task<IActionResult> Create([FromBody] AddWalkDTO addWalkdto)
        {
            
                //dto to domain model
                var addWalkDomain = mapper.Map<Walk>(addWalkdto);
                await walkRepository.CreateAsync(addWalkDomain);

                //domain model to dto
                var getWalkdto = mapper.Map<GetWalkDTO>(addWalkDomain);

                //to view the created walk
                return Ok(getWalkdto);
           


        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
                                                [FromQuery] string? sortBy, [FromQuery] bool isAscending)
        {
           var walks = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending);

            //map from domain model to dto
            var walksdto = mapper.Map<List<GetWalkDTO>>(walks);

            return Ok(walksdto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var walkDomain = await walkRepository.GetByIdAsync(id);

            if (walkDomain == null)
            {
                return NotFound();
            }

            //map from domain model to dto
            var walkdto = mapper.Map<GetWalkDTO>(walkDomain);

            //return walk dto
            return Ok(walkdto);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        [validateModelAttributes]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkDTO updateWalkDTO)
        {
            
                //map from dto to domain
                var walkDomain = mapper.Map<Walk>(updateWalkDTO);

                walkDomain = await walkRepository.UpdateAsync(id, walkDomain);

                if (walkDomain == null)
                {
                    return NotFound();
                }

                //map from domain to dto
                var walkdto = mapper.Map<UpdateWalkDTO>(walkDomain);

                return Ok(walkdto);
            

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomain = await walkRepository.DeleteAsync(id);

            if (walkDomain == null)
            {
                return NotFound();
            }

            //map from domain to dto
            var walkdto = mapper.Map<GetWalkDTO>(walkDomain);

            return Ok(walkdto);
        }

    }
}

