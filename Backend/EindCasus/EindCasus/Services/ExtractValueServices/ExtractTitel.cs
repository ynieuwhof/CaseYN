using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;

namespace EindCasus.Services.ExtractValueServices
{
    public class ExtractTitel : IExtractTitel
    {
        public string Parse(string[] groepjes)
        {
            return groepjes[0][7..];
        }

        public string ValidateTitel(string[] groepjes)
        {
            string titelRegel = groepjes[0].Substring(0, 7);

            if (!titelRegel.Equals("Titel: "))
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
