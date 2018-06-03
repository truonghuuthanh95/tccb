using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class HighestLevelEducationRepository : IHighestLevelEducationRepository
    {
        EmployeeManagementDB _db;

        public HighestLevelEducationRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<HighestLevelEducation> GetHighestLevelEducations()
        {
            List<HighestLevelEducation> highestLevelEducations = _db.HighestLevelEducations.ToList();
            return highestLevelEducations;
        }
    }
}