using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Models
{
    public class Particulier : Cursist
    {
        [MaxLength(200)]
        public string StraatNaam { get; set; }
        
        [MaxLength(6)]
        public int HuisNummer { get; set; }

        [MaxLength(6)]
        public string PostCode { get; set; }

        [MaxLength(100)]
        public string WoonPlaats { get; set; }

        [StringLength(18, MinimumLength = 18)]
        public string RekeningNummer { get; set; }
    }
}
