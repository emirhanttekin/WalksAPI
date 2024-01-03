using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalksAPI.Data;
using WalksAPI.Models.Domain;

namespace WalksAPI.Controllers
{
   
    // https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]


    public class RegionsController : ControllerBase
    {
        private readonly TrWalksDbContext dbContext;

        public RegionsController(TrWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get All Regions
        //Get : https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
          var regions =  dbContext.Regions.ToList();
            

            return Ok(regions);
        }
        //GET SINGLE REGION  (Get Region By Id)
        //Get : https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute]Guid id) {
           //var regions = dbContext.Regions.Find(id);
           var region = dbContext.Regions.FirstOrDefault(r => r.Id == id);

            if(region == null)
            {
                return NotFound();  
            }

            return Ok(region);

        }
    }
}
