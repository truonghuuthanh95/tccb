using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class StatusWorikingInEducationRepository : IStatusWorikingInEducationRepository
    {
        EmployeeManagementDB _db;

        public StatusWorikingInEducationRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<StatusWorikingInEducation> GetStatusWorikingInEducations()
        {
            List<StatusWorikingInEducation> statusWorikingInEducations = _db.StatusWorikingInEducations.Where(s => s.IsActive == true).ToList();
            return statusWorikingInEducations;
        }
    }
}