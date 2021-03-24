using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Models;


namespace EindCasus.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CursusDbContext _context)
        {
            _context.Database.EnsureCreated();

            if (_context.Cursussen.Any())
            {
                return;
            }

            _context.Cursussen.Add(new Cursus{ Duur = 5, Titel = "C# Programmeren", Code = "CNETIN" });
            _context.Cursussen.Add(new Cursus { Duur = 2, Titel = "Java Persistence API", Code = "JPA" });
            _context.Cursussen.Add(new Cursus { Duur = 5, Titel = "Angular", Code = "Ang" });
            _context.SaveChanges();

            _context.CursusInstanties.Add(new CursusInstantie { StartDatum = new DateTime(2021, 3, 22), CursusId = 1 });
            _context.CursusInstanties.Add(new CursusInstantie { StartDatum = new DateTime(2021, 3, 23), CursusId = 2 });
            _context.CursusInstanties.Add(new CursusInstantie { StartDatum = new DateTime(2021, 3, 24), CursusId = 3 });

            _context.SaveChanges();
        }
    }
}
