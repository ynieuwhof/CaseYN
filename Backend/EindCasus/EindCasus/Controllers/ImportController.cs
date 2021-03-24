using EindCasus.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EindCasus.Interfaces;
using EindCasus.Services;

namespace EindCasus.Controllers
{
    [Route("api/import")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private ICursusImporterService cursusImporterService;

        public ImportController(ICursusImporterService cursusImporterService)
        {
            this.cursusImporterService = cursusImporterService;
        }

        [HttpPost]
        public ImportDetails ImportCursus(IEnumerable<string> cursussen)
        {
            return cursusImporterService.AddCourse(cursussen);
        }
    }
}
