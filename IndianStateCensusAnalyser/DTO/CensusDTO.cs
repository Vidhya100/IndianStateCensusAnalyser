using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyser.POCO
{
    public class CensusDTO
    {
            public string State { get; set; }
            public long Population { get; set; }
            public long Area { get; set; }
            public long Density { get; set; }


        public CensusDTO(CensusDataDAO censusDataDAO)
            {
                this.State = censusDataDAO.state;
                this.Population = censusDataDAO.population;
                this.Area = censusDataDAO.area;
                this.Density = censusDataDAO.density;
            }
        
    }
}

