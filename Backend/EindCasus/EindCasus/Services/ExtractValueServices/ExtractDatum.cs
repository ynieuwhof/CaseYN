using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;
using System.Text.RegularExpressions;

namespace EindCasus.Services.ExtractValueServices
{
    public class ExtractDatum : IExtractDatum
    {
        public DateTime Parse(string[] groepjes)
        {
            return Convert.ToDateTime(groepjes[3][12..]);
        }

        public string ValidateDatum(string[] groepjes)
        {
            string datumRegel = groepjes[3];

            bool formaat = DateTime.TryParse(datumRegel[12..], out DateTime result);

            if (!datumRegel.Substring(0,12).Equals("Startdatum: "))
            {
                return "Incorrect formaat: Controleer of de gegevens van de instanties in deze volgorde staan: [Titel - Cursuscode - Duur - Startdatum]";
            } 
            else if (formaat == false)
            {
                return "Incorrect formaat: Heeft u de startdatum in het goede formaat opgegeven? [Startdatum: dd/mm/jjjj]";
            }
            else
            {
                return null;
            }
        }
    }
}
