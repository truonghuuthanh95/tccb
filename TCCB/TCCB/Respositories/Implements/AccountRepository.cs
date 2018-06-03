using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Repositories.Implements
{
    public class AccountRepository : IAccountRepository
    {
        EmployeeManagementDB _db;

        public AccountRepository(EmployeeManagementDB db)
        {
            _db = db;
        }

        public Account GetAccountByUsernameAndPassword(string username, string password)
        {
            Account account = _db.Accounts.Include("Role").Include("ManagementUnit").Where(s => s.Username == username).Where(s => s.Password == password).SingleOrDefault();
            return account;
        }
    }
}