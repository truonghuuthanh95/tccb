using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class DegreeClassificationRepository : IDegreeClassificationRepository
    {
        EmployeeManagementDB _db;

        public DegreeClassificationRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<DegreeClassification> GetDegreeClassifications()
        {
            List<DegreeClassification> degreeClassifications = _db.DegreeClassifications.Where(s => s.IsActive == true).ToList();
            return degreeClassifications;
        }
    }
}