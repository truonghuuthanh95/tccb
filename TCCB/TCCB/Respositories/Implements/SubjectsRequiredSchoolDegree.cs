using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB.Models.DAO;
using TCCB.Respositories.Interfaces;

namespace TCCB.Respositories.Implements
{
    public class SubjectsRequiredSchoolDegree : ISubjectsRequiredSchoolDegreeRepository
    {
        EmployeeManagementDB _db;

        public SubjectsRequiredSchoolDegree(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<SubjectRequiredSchoolDegree> GetSubjectRequiredSchoolDegreesBySchoolDegree(int? id)
        {
            List<SubjectRequiredSchoolDegree> subjectRequiredSchoolDegrees = _db.SubjectRequiredSchoolDegrees.Include("Subject.PositionInterview").Where(s => s.SchoolDegreeId == id).ToList();
            return subjectRequiredSchoolDegrees;
        }
    }
}