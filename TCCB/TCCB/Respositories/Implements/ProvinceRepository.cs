using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class ProvinceRepository : IProvinceRepository
    {
        EmployeeManagementDB _db;

        public ProvinceRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<Province> GetProvinceByCountryId(int id)
        {
            List<Province> provinces = _db.Provinces.Where(s => s.CountryId == id).OrderBy(s => s.Name).ToList();
            return provinces;
        }
    }
}