using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;

namespace EindCasus.Services.ExtractValueServices
{
    public class ExtractDuur : IExtractDuur
    {

        public int ValidateDuur(string duurRegel)
        {

            if (duurRegel.Length < 6)
            {
                throw new ValidationException("Duur ontbreekt");
            }
            else if (!duurRegel.Substring(0, 6).Equals("Duur: "))
            {
                throw new ValidationException("Duur ontbreekt");
            }
            else if (!duurRegel[7..].Equals(" dagen"))
            {
                throw new ValidationException("Zet de duur op de volgende manier neer [Duur: {getal} dagen]");
            }
            else
            {
                return int.Parse(duurRegel[6].ToString()); ;
            }
        }
    }
}
