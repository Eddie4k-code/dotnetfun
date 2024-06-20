using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Domain;
using Models.DTO;
using Repositories.IRegionRepository;

namespace dotnetfun.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public Task<Region> Create(CreateRegionDto createRegionDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Region>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Region> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}