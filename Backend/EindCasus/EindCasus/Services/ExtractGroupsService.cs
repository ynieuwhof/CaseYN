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

        public string ValidateLength(string[] input)
        {
            if(input.Length > 4)
            {
                return "Incorrect formaat: geen witte regel tussen instanties";
            }
            else if(input.Length < 4)
            {
                return "Incorrect formaat: niet alle velden zijn ingevuld";
            }
            else
            {
                return null;
            }
        }
    }
}
