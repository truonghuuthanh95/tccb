using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB.Models.DAO;

namespace TCCB.Respositories.Interfaces
{
    public interface ISubjectsRequiredSchoolDegreeRepository
    {
        List<SubjectRequiredSchoolDegree> GetSubjectRequiredSchoolDegreesBySchoolDegree(int? id);
    }
}