using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Models.DTO;


namespace API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase {
        private NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAll() {


            var regions = dbContext.Regions.ToList();

            var regionsDto = new List<RegionDto>();

            foreach (var r in regions) {
                regionsDto.Add(new RegionDto(){
                    ID = r.ID,
                    Code = r.Code,
                    Name = r.Name,
                    RegionImageUrl = r.regionImageUrl
                });
            }


    
            return Ok(regionsDto);
            
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute]Guid id) {

            var region = this.dbContext.Regions.FirstOrDefault(x => x.ID == id);

            

            if (region == null) {
                return NotFound();
            } 

            var regionDto = new RegionDto(){
                ID = region.ID,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.regionImageUrl
            };

            return Ok(regionDto);

        }


        [HttpPost]
        public IActionResult Create([FromBody]CreateRegionDto createRegionDto) {

            //Map and convert DTO to domain model.
            var newRegion = new Region(){
                Code = createRegionDto.Code,
                Name = createRegionDto.Name,
                regionImageUrl = createRegionDto.RegionImageUrl
            };


            //use domain model to create region

            this.dbContext.Add(newRegion);

            this.dbContext.SaveChanges();
            
        
            return Ok(createRegionDto);
        }
        
    }
}