using EindCasus.Data;
using EindCasus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;

namespace EindCasus.Repositories
{
    public class ImportCursusRepository : IImportCursusRepository
    {
        private readonly CursusDbContext _context;

        public ImportCursusRepository(CursusDbContext context)
        {
            this._context = context;
        }

        public void AddNewCourse(int duur, string titel, string code)
        {
            _context.Cursussen.Add(new Cursus { Duur = duur, Titel = titel, Code = code });
            _context.SaveChanges();
        }

        public void AddCourseInstance(DateTime startDatum, int cursusId)
        {
            _context.Add(new CursusInstantie { StartDatum = startDatum, CursusId = cursusId });
            _context.SaveChanges();
        }
    }
}
