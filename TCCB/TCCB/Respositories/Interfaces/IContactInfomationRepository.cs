using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB.Models.DAO;

namespace TCCB.Repositories.Interfaces
{
    public interface IContactInfomationRepository
    {
        List<ContactInfomation> GetContactInfomations();
    }
}