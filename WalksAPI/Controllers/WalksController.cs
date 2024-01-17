using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WalksAPI.CustomActionFilters;
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
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequesDto addWalkRequesDto)
        {
        
                var walkDomainModel = mapper.Map<Walk>(addWalkRequesDto);
                await walkRepository.CreateAsync(walkDomainModel);
                //Map Domain modelDto

                return Ok(mapper.Map<WalkDto>(walkDomainModel));
       

       
        }

        //Get Walks 
        // Get: /api /walks

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();
            //Map Domain Model to DTO

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        //Get Walk By Id
        // Get: /api/Walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to Dto
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //Update Walk By Id 
        //Put: /api/Walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}