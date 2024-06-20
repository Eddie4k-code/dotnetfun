using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Models.Domain;
using Repositories.IRegionRepository;
using Microsoft.EntityFrameworkCore;
using Models.DTO;

namespace dotnetfun.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepository(NZWalksDbContext dbContext) {
            this.dbContext = dbContext;
        } 

        public async Task<List<Region>> GetAll()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetById(Guid id)
        {
            return await this.dbContext.Regions.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Region> Create(CreateRegionDto createRegionDto) {
            
            
            //Map and convert DTO to domain model.
            var newRegion = new Region(){
                Code = createRegionDto.Code,
                Name = createRegionDto.Name,
                regionImageUrl = createRegionDto.RegionImageUrl
            };
            
            await this.dbContext.AddAsync(newRegion);

            await this.dbContext.SaveChangesAsync();

            return newRegion;
        }

    }
}