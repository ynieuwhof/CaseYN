using EindCasus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Interfaces
{
    public interface ICursusRepository
    {
        IEnumerable<CursusDetails> GetAllCourses();

        bool CheckIfCourseExists(string code);

        int GetCourseIdByCode(string code);

        bool CheckIfCourseInstanceExisits(DateTime startDatum, int cursusId);
    }
}
