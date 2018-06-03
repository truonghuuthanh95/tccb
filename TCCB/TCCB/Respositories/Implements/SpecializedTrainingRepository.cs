using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class SpecializedTrainingRepository : ISpecializedTrainingRepository
    {
        EmployeeManagementDB _db;

        public SpecializedTrainingRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<SpecializedTraining> GetSpecializedTrainings()
        {
            List<SpecializedTraining> specializedTrainings = _db.SpecializedTrainings.Where(s => s.IsActive == true).OrderBy(s => s.Name).ToList();
            return specializedTrainings;
        }
    }
}