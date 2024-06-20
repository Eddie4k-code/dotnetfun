using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Models.DTO;
using Repositories.IRegionRepository;


namespace API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase {
        private NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() {


            var regions = await dbContext.Regions.ToListAsync();

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
        public async Task<IActionResult> GetById([FromRoute]Guid id) {

            var region = await this.dbContext.Regions.FirstOrDefaultAsync(x => x.ID == id);

            

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
        public async Task<IActionResult> Create([FromBody]CreateRegionDto createRegionDto) {

            //Map and convert DTO to domain model.
            var newRegion = new Region(){
                Code = createRegionDto.Code,
                Name = createRegionDto.Name,
                regionImageUrl = createRegionDto.RegionImageUrl
            };


            //use domain model to create region

            await this.dbContext.AddAsync(newRegion);

            await this.dbContext.SaveChangesAsync();
            
        
            return Ok(createRegionDto);
        }
        
    }
}