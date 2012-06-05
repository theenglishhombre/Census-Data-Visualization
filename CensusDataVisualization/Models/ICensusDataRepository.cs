using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CensusDataVisualization.Models
{
    public interface ICensusDataRepository
    {
        IQueryable<SF1_00003> FindAllRegionsOrderByPopulationDesc();
        IQueryable<SF1_00003> FindAllRegions();
        IQueryable<SF1_00003> FindAllRegionsOrdered();
        IQueryable<SF1_00003> FindAllPopulatedRegionsOrdered();

        SF1_00003 GetRegion(int id);
    }
}
