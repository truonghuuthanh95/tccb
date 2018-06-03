using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class GraduationClassficationRepository : IGraduationClassficationRepository
    {
        EmployeeManagementDB _db;

        public GraduationClassficationRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<GraduationClassfication> GetGraduationClassfications()
        {
            List<GraduationClassfication> graduationClassfications = _db.GraduationClassfications.Where(s => s.IsActive == true).ToList();
            return graduationClassfications;
        }
    }
}