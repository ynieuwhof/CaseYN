using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EindCasus.Interfaces;
using EindCasus.DTO;

namespace EindCasus.Controllers
{
    [Route("api/import")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly ICursusImporterService cursusImporterService;

        public ImportController(ICursusImporterService cursusImporterService)
        {
            this.cursusImporterService = cursusImporterService;
        }

        [HttpPost]
        public ImportFeedback ImportCursus(string[] cursussen)
        {
            return cursusImporterService.AddCourse(cursussen[0]);
        }
    }
}
