using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class InformationTechnologyDegreeRepository : IInformationTechnologyDegree
    {
        EmployeeManagementDB _db;

        public InformationTechnologyDegreeRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<InfomationTechnologyDegree> GetAllInfomationTechnologyDegree()
        {
            List<InfomationTechnologyDegree> informationTechnologyDegrees = _db.InfomationTechnologyDegrees.Where(s => s.IsActive == true).ToList();
            return informationTechnologyDegrees;
        }
    }
}