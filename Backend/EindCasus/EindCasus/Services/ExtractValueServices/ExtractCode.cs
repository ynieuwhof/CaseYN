using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;

namespace EindCasus.Services.ExtractValueServices
{
    public class ExtractCode : IExtractCode
    {

        public string ValidateCode(string codeRegel)
        {
            if(codeRegel.Length < 13)
            {
                throw new ValidationException("Cursuscode ontbreekt");
            }
            else if (!codeRegel.Substring(0,12).Equals("Cursuscode: "))
            {
                throw new ValidationException("Cursuscode ontbreekt");

            }
            else
            {
                return codeRegel[12..];
            }
        }
    }
}
