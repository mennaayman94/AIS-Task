using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.ModelBinding;
using WebApplication1.Models;
using WebApplication1.RepoImp;

namespace WebApplication1.Business_Layer
{
    public class AccountBL
    {
        Repository<Account> repo = new Repository<Account>(new Accounts_DBEntities());
        Accounts_DBEntities db = new Accounts_DBEntities();
        public IEnumerable<AccountDTO> GetAccounts()
        {

            var acc = repo.GetAll().Include(x => x.AccountsCategory).Include(x => x.AccountsType).ToList();
            return Mapper.Map<List<AccountDTO>>(acc);
        }
        public Account  CreateAccount(AddAcountDTO accDTO)
        {
            if (accDTO.CategoryID != null && accDTO.TypeID != null)
            {
                var acc = Mapper.Map<AddAcountDTO, Account>(accDTO);
                repo.Add(acc);
                
                return acc;
            }
            return null;
           

        }
        public Account PutAccount( AccountDTO accDTO)
        {
            if (accDTO.TypeID!=null&&accDTO.CategoryID!=null) {
                var acc = Mapper.Map<AccountDTO, Account>(accDTO);

                repo.Edit(acc);
                
                return acc;
            }
            else
            {
                return null;
            }

        }
        public Account DeleteAccount(int id)
        {
                Account account = repo.GetById(id);
            if (account.ID==id) { 
                repo.Remove(account);


                return account;
            }
            else
            {
                return null;
            }
        }

        private void AddtoDb(AccountsLog log)
        {
            var ent = db.AccountsLogs.Add(log);
            db.SaveChanges();
        }

    }
}