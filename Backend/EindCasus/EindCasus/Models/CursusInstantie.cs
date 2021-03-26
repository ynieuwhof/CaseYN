using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Models
{
    public class CursusInstantie
    {
        public int Id { get; set; }
        
        public DateTime StartDatum { get; set; }

        public int CursusId { get; set; }

    }
}
