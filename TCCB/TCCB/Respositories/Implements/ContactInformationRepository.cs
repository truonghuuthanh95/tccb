using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;

namespace TCCB.Repositories.Implements
{
    public class ContactInformationRepository : IContactInfomationRepository
    {
        EmployeeManagementDB _db;

        public ContactInformationRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public List<ContactInfomation> GetContactInfomations()
        {
            List<ContactInfomation> contactInfomations = _db.ContactInfomations.Include("ManagementUnit").ToList();
            return contactInfomations;
        }
    }
}