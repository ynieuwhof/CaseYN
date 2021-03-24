using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Models
{
    public class BedrijfsMedewerker : Cursist
    {
        [MaxLength(200)]
        public string BedrijfsNaam { get; set; }

        [MaxLength(200)]
        public string Afdeling { get; set; }

        [MaxLength(30)]
        public string OfferteNummer { get; set; }
    }
}
