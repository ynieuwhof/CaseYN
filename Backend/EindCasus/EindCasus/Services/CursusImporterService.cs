using EindCasus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;
using System.ComponentModel.DataAnnotations;
using EindCasus.DTO;

namespace EindCasus.Services
{
    public class CursusImporterService : ICursusImporterService
    {
        private readonly ICursusRepository cursusRepository;
        private readonly IImportCursusRepository importCursusRepository;
        private readonly IExtractDatum extractDatum;
        private readonly IExtractDuur extractDuur;
        private readonly IExtractTitel extractTitel;
        private readonly IExtractCode extractCode;
        private readonly IEmptyLineValidator emptyLineValidator;

        public CursusImporterService(
            IImportCursusRepository importCursusRepository,
            ICursusRepository cursusRepository,
            IExtractDatum extractDatum,
            IExtractTitel extractTitel,
            IExtractCode extractCode,
            IExtractDuur extractDuur,
            IEmptyLineValidator emptyLineValidator)
        {
            this.importCursusRepository = importCursusRepository;
            this.cursusRepository = cursusRepository;
            this.extractDatum = extractDatum;
            this.extractTitel = extractTitel;
            this.extractCode = extractCode;
            this.extractDuur = extractDuur;
            this.emptyLineValidator = emptyLineValidator;
        }

        public ImportFeedback AddCourse(string cursussen)
        {
            int aantalCursussen = 0;
            int aantalInstanties = 0;
            int aantalDuplicaten = 0;
            string errorMessage = ""; 

            string[] alleRegels = cursussen.Split("\n");
            int huidigeRegel = 0;

            try
            {

                while (huidigeRegel < alleRegels.Length -1)
                {
                    string titel = extractTitel.ValidateTitel(alleRegels[huidigeRegel]);
                    huidigeRegel++;

                    string code = extractCode.ValidateCode(alleRegels[huidigeRegel]);
                    huidigeRegel++;

                    int duur = extractDuur.ValidateDuur(alleRegels[huidigeRegel]);
                    huidigeRegel++;

                    DateTime date = extractDatum.ValidateDatum(alleRegels[huidigeRegel]);
                    huidigeRegel++;

                    string legeRegel = emptyLineValidator.CheckForEmptyLine(alleRegels[huidigeRegel]);
                    huidigeRegel++;


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
            catch(ValidationException e)
            {
                errorMessage = $"Incorrect formaat op regel {huidigeRegel + 1} : {e.Message}";
                return new ImportFeedback() { ToegevoegdeCursussen = aantalCursussen, ToegevoegdeInstanties = aantalInstanties, AantalDuplicaten = aantalDuplicaten, ErrorMessage = errorMessage };
            }

            return new ImportFeedback(){ ToegevoegdeCursussen = aantalCursussen, ToegevoegdeInstanties = aantalInstanties, AantalDuplicaten = aantalDuplicaten, ErrorMessage = errorMessage};
            
        }
    }
}
