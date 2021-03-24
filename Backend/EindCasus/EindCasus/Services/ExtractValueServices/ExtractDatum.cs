using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;

namespace EindCasus.Services.ExtractValueServices
{
    public class ExtractDatum : IExtractDatum
    {
        public DateTime Parse(string[] groepjes)
        {
            return Convert.ToDateTime(groepjes[3][12..]);
        }
    }
}
