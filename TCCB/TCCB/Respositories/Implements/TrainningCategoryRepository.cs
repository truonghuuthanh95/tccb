using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class TrainningCategoryRepository : ITrainningCategoryRepository
    {
        EmployeeManagementDB _db;

        public TrainningCategoryRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<TrainningCategory> GetTrainningCategories()
        {
            List<TrainningCategory> trainningCategories = _db.TrainningCategories.Where(s => s.IsActive == true).ToList();
            return trainningCategories;
        }
    }
}