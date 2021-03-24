using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Interfaces
{
    public interface IExtractTitel
    {
        string Parse(string[] groepjes);

        string ValidateTitel(string[] groepjes);
    }
}
