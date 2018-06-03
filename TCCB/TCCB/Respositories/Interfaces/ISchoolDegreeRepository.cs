using TCCB.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Interfaces
{
    public interface ISchoolDegreeRepository
    {
        List<SchoolDegree> GetSchoolDegrees();
    }
}