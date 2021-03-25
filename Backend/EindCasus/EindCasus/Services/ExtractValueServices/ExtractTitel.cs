using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;

namespace EindCasus.Services.ExtractValueServices
{
    public class ExtractTitel : IExtractTitel
    {

        public string ValidateTitel(string titelRegel)
        {
            if (titelRegel.Length < 7)
            {
                throw new ValidationException("Titel ontbreekt");
            }
            if (!titelRegel.Substring(0,7).Equals("Titel: "))
            {
                throw new ValidationException("Titel ontbreekt");
            }
            else
            {
                return titelRegel[7..];
            }
        }
    }
}
