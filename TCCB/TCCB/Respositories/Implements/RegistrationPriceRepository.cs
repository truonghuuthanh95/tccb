using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class RegistrationPriceRepository : IRegistrationPriceRepository
    {

        EmployeeManagementDB _db;

        public RegistrationPriceRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public RegistrationPrice GetRegistrationPriceByManagementUnitId(int? managementUnitId)
        {
            RegistrationPrice registrationPrice = _db.RegistrationPrices.SingleOrDefault(s => s.ManagementUnitId == managementUnitId);
            return registrationPrice;
        }
    }
}