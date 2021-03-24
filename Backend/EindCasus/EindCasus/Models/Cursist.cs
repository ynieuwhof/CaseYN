using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Models
{
    public class Cursist
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Naam { get; set; }

        [MaxLength(200)]
        public string AchterNaam { get; set; }

        public ICollection<CursusInstantie> CursusInstanties { get; set; }
    }
}
