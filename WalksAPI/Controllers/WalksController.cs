using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalksAPI.Models.Domain;
using WalksAPI.Models.Domain.DTO;
using WalksAPI.Repositories;

namespace WalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        //CREATE Walk
        //POST : /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequesDto addWalkRequesDto)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequesDto);
            await walkRepository.CreateAsync(walkDomainModel);
            //Map Domain modelDto

            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }

        //Get Walks 
        // Get: /api /walks

        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
           var walksDomainModel = await walkRepository.GetAllAsync();
            //Map Domain Model to DTO

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

    }
}
