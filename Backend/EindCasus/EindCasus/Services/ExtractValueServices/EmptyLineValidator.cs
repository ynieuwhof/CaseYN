using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace EindCasus.Services.ExtractValueServices
{
    public class EmptyLineValidator : IEmptyLineValidator
    {
        public string CheckForEmptyLine(string legeRegel)
        {
            Regex reg = new(@"^.{0}$");

            if(!reg.Match(legeRegel).Success)
            {
                throw new ValidationException("Geen lege regel tussen de cursusinstanties");
            }
            else
            {
                return "Ok";
            }
        }
    }
}
