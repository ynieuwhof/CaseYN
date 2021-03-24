using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Interfaces
{
    public interface IExtractDuur
    {
        int Parse(string[] groepjes);

        string ValidateDuur(string[] groepjes);
    }
}
