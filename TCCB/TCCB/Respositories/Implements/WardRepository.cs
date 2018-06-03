using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class WardRepository : IWardRepository
    {
        EmployeeManagementDB _db;

        public WardRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<Ward> GetWardByDistrictId(int id)
        {
            List<Ward> wards = _db.Wards.Where(s => s.DistrictID == id).OrderBy(s => s.Name).ToList();
            return wards;
        }
    }
}