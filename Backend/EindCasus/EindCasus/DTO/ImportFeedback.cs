using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.DTO
{
    public class ImportFeedback
    {
        public int ToegevoegdeCursussen { get; set; }

        public int ToegevoegdeInstanties { get; set; }

        public int AantalDuplicaten { get; set; }

        public string ErrorMessage { get; set; }
    }
}
