using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;

namespace EindCasus.Services.ExtractValueServices
{
    public class ExtractDuur : IExtractDuur
    {
        public int Parse(string[] groepjes)
        {
            return int.Parse(groepjes[2][6].ToString());
        }

        public string ValidateDuur(string[] groepjes)
        {
            string duurRegel = groepjes[2].Substring(0, 6);

            if (!duurRegel.Equals("Duur: "))
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
