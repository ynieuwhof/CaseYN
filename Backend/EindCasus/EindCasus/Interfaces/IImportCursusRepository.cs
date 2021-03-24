using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Interfaces
{
    public interface IImportCursusRepository
    {
        void AddNewCourse(char duurString, string titel, string code);

        void AddCourseInstance(DateTime startDatum, int cursusId);
    }
}
