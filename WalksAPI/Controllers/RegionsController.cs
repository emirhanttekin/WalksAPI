using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalksAPI.CustomActionFilters;
using WalksAPI.Data;
using WalksAPI.Models.Domain;
using WalksAPI.Models.Domain.DTO;
using WalksAPI.Repositories;

namespace WalksAPI.Controllers
{

    // https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]


    public class RegionsController : ControllerBase
    {
        private readonly TrWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(TrWalksDbContext dbContext , IRegionRepository regionRepository, 
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        //Get All Regions
        //Get : https://localhost:portnumber/api/regions
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        {
            //Get Data From Database - Domain Models 
            var regionsDomain = await regionRepository.GetAllAsync();
           
         //Reterns DTOs
            return Ok(mapper.Map<List<Region>>(regionsDomain));
        }
        //GET SINGLE REGION  (Get Region By Id)
        //Get : https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
		[Authorize(Roles = "Emir")]
		public async Task<IActionResult>  GetById([FromRoute] Guid id) {
            //var regions = dbContext.Regions.Find(id);
            //Get Region Domain Model From Database 
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //Return DTO back to client 
            return Ok(mapper.Map<RegionDto>(regionDomain));

        }
        //Post to create new region 
        // POST : https://localhost:portnumber/api/regions/

        [HttpPost]
        [ValidateModel]
		[Authorize(Roles = "Emir")]
		public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
           
                //Map or Convert DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
         
                //Use Domain Model to create Region
                regionDomainModel =await regionRepository.CreateAsync(regionDomainModel);
                //MAP Domain model back to DTO
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);
          
                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto); 
           
        
        }


        //Update Region 
        //PUT: https://localhost:portnumber/api/regions/{id}

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
		[Authorize (Roles = "Emir")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
          
                // Map Dto to Domain Model
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
                if(regionDomainModel == null)
                {
                    return NotFound();

                }
          

                await dbContext.SaveChangesAsync();
                //Convert Domain Model to Dto
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return Ok(regionDto);
        
       
            
        } 

        //Delete Region 
        //DELETE : https://localhost:portnumber/api/regions/{id}

        [HttpDelete]
        [Route("{id:Guid}")]
		[Authorize(Roles = "Emir , Reader")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           var regionDomainModel = await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
                             

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
