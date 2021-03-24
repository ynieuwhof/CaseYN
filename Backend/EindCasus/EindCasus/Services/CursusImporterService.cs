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
        private IExtractDuur extractDuur;
        private IExtractTitel extractTitel;
        private IExtractCode extractCode;

        public CursusImporterService(
            IExtractGroupsService extractGroupsService,
            IImportCursusRepository importCursusRepository,
            ICursusRepository cursusRepository,
            IExtractDatum extractDatum,
            IExtractTitel extractTitel,
            IExtractCode extractCode,
            IExtractDuur extractDuur)
        {
            this.extractGroupsService = extractGroupsService;
            this.importCursusRepository = importCursusRepository;
            this.cursusRepository = cursusRepository;
            this.extractDatum = extractDatum;
            this.extractTitel = extractTitel;
            this.extractCode = extractCode;
            this.extractDuur = extractDuur;
        }

        public ImportDetails AddCourse(IEnumerable<string> cursussen)
        {
            int aantalCursussen = 0;
            int aantalInstanties = 0;
            int aantalDuplicaten = 0;
            
            List<string> errorMessage = new();

            foreach(string cursus in cursussen)
            {
                string[] groepjes = extractGroupsService.ExtractGroups(cursus);
                errorMessage.Add(extractGroupsService.ValidateLength(groepjes));
                errorMessage.RemoveAll(x => x == null);

                if(errorMessage.Count == 0)
                {                                  
                    errorMessage.Add(extractTitel.ValidateTitel(groepjes));
                    errorMessage.Add(extractCode.ValidateCode(groepjes));
                    errorMessage.Add(extractDuur.ValidateDuur(groepjes));
                    errorMessage.Add(extractDatum.ValidateDatum(groepjes));

                    errorMessage.RemoveAll(x => x == null);

                    if (errorMessage.Count == 0)
                    {
                        string titel = extractTitel.Parse(groepjes);
                        string code = extractCode.Parse(groepjes);
                        int duur = extractDuur.Parse(groepjes);
                        DateTime date = extractDatum.Parse(groepjes);

                        bool cursusExists = cursusRepository.CheckIfCourseExists(code);
                        int cursusId;
                        bool instanceExists;

                        if (!cursusExists)
                        {
                            importCursusRepository.AddNewCourse(duur, titel, code);
                            aantalCursussen++;
                            cursusId = cursusRepository.GetCourseIdByCode(code);
                            importCursusRepository.AddCourseInstance(date, cursusId);
                            aantalInstanties++;
                        }
                        else
                        {
                            cursusId = cursusRepository.GetCourseIdByCode(code);
                            instanceExists = cursusRepository.CheckIfCourseInstanceExisits(date, cursusId);
                            if (instanceExists)
                            {
                                aantalDuplicaten++;
                            }
                            else
                            {
                                importCursusRepository.AddCourseInstance(date, cursusId);
                                aantalInstanties++;
                            }
                        }
                    }
                    
                }
                
            }

            return new ImportDetails(){ ToegevoegdeCursussen = aantalCursussen, ToegevoegdeInstanties = aantalInstanties, AantalDuplicaten = aantalDuplicaten, ErrorMessage = errorMessage};
            
        }
    }
}
