using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;
using System.Text.RegularExpressions;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace EindCasus.Services.ExtractValueServices
{
    public class ExtractDatum : IExtractDatum
    {

        public DateTime ValidateDatum(string datumRegel)
        {

            if(datumRegel.Length < 14)
            {
                throw new ValidationException("Datum ontbreekt");
            }
            else if (!datumRegel.Substring(0,12).Equals("Startdatum: "))
            {
                throw new ValidationException("Datum ontbreekt");
            }

            bool formaat = DateTime.TryParseExact(datumRegel[12..], new string[] { "dd/MM/yyyy", "d/MM/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);
            
            if (formaat == false)
            {
                throw new ValidationException("Heeft u de startdatum in het goede formaat opgegeven? [Startdatum: dd/mm/jjjj]");
            }
            else
            {
                return Convert.ToDateTime(datumRegel[12..]);
            }
        }
    }
}
