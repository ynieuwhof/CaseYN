using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;

namespace EindCasus.Services.ExtractValueServices
{
    public class ExtractCode : IExtractCode
    {
        public string Parse(string[] groepjes)
        {
            return groepjes[1][12..];
        }

        public string ValidateCode(string[] groepjes)
        {
            string codeRegel = groepjes[1].Substring(0, 12);

            if (!codeRegel.Equals("Cursuscode: "))
            {
                return "Incorrect formaat: Controleer of de gegevens van de instanties in deze volgorde staan: [Titel - Cursuscode - Duur - Startdatum]";
            }
            else
            {
                return null;
            }
        }
    }
}
