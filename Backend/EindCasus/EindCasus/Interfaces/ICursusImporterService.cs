using EindCasus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EindCasus.Interfaces
{
    public interface ICursusImporterService
    {
        ImportDetails AddCourse(string cursussen);

    }
}
