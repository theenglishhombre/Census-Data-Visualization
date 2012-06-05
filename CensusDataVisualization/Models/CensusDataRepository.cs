using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CensusDataVisualization.Models
{
    public class CensusDataRepository : ICensusDataRepository
    {
        Census2010Entities db = new Census2010Entities();

        public SF1_00003 GetRegion(int id)
        {
            return db.SF1_00003.SingleOrDefault(d => d.LOGRECNO == id);
        }

        public IQueryable<SF1_00003> FindAllRegions()
        {
            return db.SF1_00003;
        }

        public IQueryable<SF1_00003> FindAllRegionsOrderByPopulationDesc()
        {
            return from SF1_00003 in FindAllRegions()
                   orderby SF1_00003.White_Alone descending
                   select SF1_00003;
        }

        public IQueryable<SF1_00003> FindAllRegionsOrdered()
        {
            return from SF1_00003 in FindAllRegions()
                   orderby SF1_00003.LOGRECNO
                   select SF1_00003;
        }

        public IQueryable<SF1_00003> FindAllPopulatedRegionsOrdered()
        {
            return from SF1_00003 in FindAllRegions()
                   where SF1_00003.White_Alone > 0
                   orderby SF1_00003.LOGRECNO
                   select SF1_00003;
        }
    }
}