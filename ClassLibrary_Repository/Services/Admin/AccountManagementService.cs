using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace ClassLibrary_RepositoryDLL.Services.Admin
{
    public class AccountManagementService
    {
        private readonly IAccountRepository _accountRepo;
        public bool checkLogin(string username, string password)
        {
            return _accountRepo.checkLogin(username, password);
        }

        public bool isExistUserName(string text)
        {
            throw new NotImplementedException();
        }

        public void AddAccount(Account newAccount)
        {
            throw new NotImplementedException();
        }
    }
}