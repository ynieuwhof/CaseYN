using EindCasus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;

namespace EindCasus.Services
{
    public class CursusImporterService : ICursusImporterService
    {
        private IExtractGroupsService extractGroupsService;
        private ICursusRepository cursusRepository;
        private IImportCursusRepository importCursusRepository;
        private IExtractDatum extractDatum;

        public CursusImporterService(
            IExtractGroupsService extractGroupsService, 
            IImportCursusRepository importCursusRepository, 
            ICursusRepository cursusRepository,
            IExtractDatum extractDatum)
        {
            this.extractGroupsService = extractGroupsService;
            this.importCursusRepository = importCursusRepository;
            this.cursusRepository = cursusRepository;
            this.extractDatum = extractDatum;
        }

        public ImportDetails AddCourse(IEnumerable<string> cursussen)
        {
            int aantalCursussen = 0;
            int aantalInstanties = 0;

            foreach(string cursus in cursussen)
            {
                string[] groepjes = extractGroupsService.ExtractGroups(cursus);
                bool cursusExists = cursusRepository.CheckIfCourseExists(groepjes[1][12..]);
                int cursusId;
                DateTime date = extractDatum.Parse(groepjes);
                bool instanceExists;

                if (!cursusExists)
                {
                    importCursusRepository.AddNewCourse(groepjes[2][6], groepjes[0][7..], groepjes[1][12..]);
                    aantalCursussen += 1;
                    cursusId = cursusRepository.GetCourseIdByCode(groepjes[1][12..]);
                    importCursusRepository.AddCourseInstance(date, cursusId);
                    aantalInstanties += 1;
                }
                else
                {
                    cursusId = cursusRepository.GetCourseIdByCode(groepjes[1][12..]);
                    instanceExists = cursusRepository.CheckIfCourseInstanceExisits(date, cursusId);
                    if (instanceExists)
                    {
                        Console.WriteLine("Deze instantie bestaat al");
                    }
                    else
                    {
                        importCursusRepository.AddCourseInstance(date, cursusId);
                        aantalInstanties += 1;
                    }
                }
            }

            return new ImportDetails(){ ToegevoegdeCursussen = aantalCursussen, ToegevoegdeInstanties = aantalInstanties};
            
        }
    }
}
