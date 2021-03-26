using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.DTO
{
    public class CursusDetails
    {
        public DateTime StartDatum { get; set; }
        public int Duur { get; set; }
        public string Titel { get; set; }
        public int InstantieId { get; set; }
    }
}
