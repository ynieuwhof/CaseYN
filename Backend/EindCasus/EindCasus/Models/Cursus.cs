using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Models
{
    public class Cursus
    {
        public int Id { get; set; }

        public int Duur { get; set; }

        [MaxLength(300)]
        public string Titel { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        public ICollection<CursusInstantie> CursusInstanties {get; set;}
    }
}
