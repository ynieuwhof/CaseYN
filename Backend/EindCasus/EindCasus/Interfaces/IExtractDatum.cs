using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Interfaces
{
    public interface IExtractDatum
    {
        DateTime Parse(string[] groepjes);
    }
}
