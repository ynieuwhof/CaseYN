using EindCasus.Models;
using EindCasus.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;

namespace EindCasus.Controllers
{
    [ApiController]
    [Route("api/cursus")]
    public class CursusController : ControllerBase
    {
        private ICursusRepository cursusRepository;

        public CursusController(ICursusRepository cursusRepository)
        {
            this.cursusRepository = cursusRepository;
        }

        [HttpGet("alle")]
        public IEnumerable<CursusDetails> GetCourses()
        {
            return cursusRepository.GetAllCourses();
        }

    }
}
