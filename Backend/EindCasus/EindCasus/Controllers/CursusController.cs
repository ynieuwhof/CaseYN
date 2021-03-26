using EindCasus.Models;
using EindCasus.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;
using EindCasus.DTO;

namespace EindCasus.Controllers
{
    [ApiController]
    [Route("api/cursussen")]
    public class CursusController : ControllerBase
    {
        private readonly ICursusRepository cursusRepository;

        public CursusController(ICursusRepository cursusRepository)
        {
            this.cursusRepository = cursusRepository;
        }

        [HttpGet]
        public IEnumerable<CursusDetails> GetCourses()
        {
            return cursusRepository.GetAllCourses();
        }

    }
}
