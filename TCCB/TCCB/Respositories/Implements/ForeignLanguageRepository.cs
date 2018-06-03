using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class ForeignLanguageRepository : IForeignLanguageRepository
    {
        EmployeeManagementDB _db;

        public ForeignLanguageRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<ForeignLanguageCertification> GetAllForeignLanguageCertification()
        {
            List<ForeignLanguageCertification> foreignLanguageCertifications = _db.ForeignLanguageCertifications.ToList();
            return foreignLanguageCertifications;
        }
    }
}