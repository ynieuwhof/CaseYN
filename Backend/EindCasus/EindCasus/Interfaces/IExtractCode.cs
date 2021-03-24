using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Interfaces
{
    public interface IExtractCode
    {
        string Parse(string[] groepjes);

        string ValidateCode(string[] groepjes);
    }
}
