using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Services
{
    public class ImportDetails
    {
        public int ToegevoegdeCursussen { get; set; }

        public int ToegevoegdeInstanties { get; set; }

        public int AantalDuplicaten { get; set; }

        public string ErrorMessage { get; set; }
    }
}
