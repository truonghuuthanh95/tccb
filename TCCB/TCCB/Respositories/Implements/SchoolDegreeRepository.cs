using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class SchoolDegreeRepository : ISchoolDegreeRepository
    {
        EmployeeManagementDB _db;

        public SchoolDegreeRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<SchoolDegree> GetSchoolDegrees()
        {
            List<SchoolDegree> schoolDegrees = _db.SchoolDegrees.Where(s => s.IsActive == true).ToList();
            return schoolDegrees;
        }
    }
}