using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Interfaces
{
    public interface IExtractGroupsService
    {
        string[] ExtractGroups(string input);

        string ValidateLength(string[] input);
    }
}
