using TCCB.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCB.Repositories.Interfaces
{
    public interface ISpecializedTrainingRepository
    {
        List<SpecializedTraining> GetSpecializedTrainings();
    }
}
