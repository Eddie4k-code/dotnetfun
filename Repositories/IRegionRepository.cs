using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Domain;
using Models.DTO;

namespace Repositories.IRegionRepository
{
    public interface IRegionRepository
    {

        Task<List<Region>> GetAll();

        Task<Region> GetById(Guid id);

        Task<Region> Create(CreateRegionDto createRegionDto);

        


        
    }
}