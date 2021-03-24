using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;

namespace EindCasus.Services
{
    public class ExtractGroupsService : IExtractGroupsService
    {
        public string[] ExtractGroups(string input)
        {
            return input.Split("\n");
        }
    }
}
