using EindCasus.Data;
using EindCasus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;
using EindCasus.DTO;

namespace EindCasus.Repositories
{
    public class CursusRepository : ICursusRepository
    {
        private readonly CursusDbContext _context;

        public CursusRepository(CursusDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<CursusDetails> GetAllCourses()
        {
            return (from c in _context.Cursussen
                    from i in c.CursusInstanties
                    select new CursusDetails { StartDatum = i.StartDatum, Duur = c.Duur, Titel = c.Titel, InstantieId = i.Id }).ToList();
        }

        public bool CheckIfCourseInstanceExisits(DateTime startDatum, int cursusId)
        {
            return _context.CursusInstanties.Any(x => x.StartDatum == startDatum) && _context.CursusInstanties.Any(x => x.CursusId == cursusId);
        }

        public bool CheckIfCourseExists(string code)
        {
            return _context.Cursussen.Any(x => x.Code == code);
        }

        public int GetCourseIdByCode(string code)
        {
            return _context.Cursussen.Where(x => x.Code == code).Select(x => x.Id).FirstOrDefault();
        }
    }
}
