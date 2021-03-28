using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.UI;
using WebApplication1.Models;
using WebApplication1.RepoImp;

namespace WebApplication1.Business_Layer
{
    public class CategoryBL
    {
        Repository<AccountsCategory> repo = new Repository<AccountsCategory>(new Accounts_DBEntities());
        Accounts_DBEntities db = new Accounts_DBEntities();

        public IEnumerable<CategoryDTO> GetCategories()
        {

            return repo.GetAll().Select(Mapper.Map<AccountsCategory, CategoryDTO>);
        }
        public AccountsCategory CreateCategory(AddCategoryDTO ctgDTO)
        {
            if (string.IsNullOrWhiteSpace(ctgDTO.CategoryName)) {
                return null;
            }
            else
            {
                //DateTime time = DateTime.Now;
                //AccountsLog log = new AccountsLog("Create", "AccountsCategory", time);

                //AddtoDb(log);
                var ctg = Mapper.Map<AddCategoryDTO, AccountsCategory>(ctgDTO);
                repo.Add(ctg);
                
                return ctg;
                
            }

        }
        public AccountsCategory PutCategory( CategoryDTO ctgDTO)
        {
            if (string.IsNullOrWhiteSpace(ctgDTO.CategoryName))
            {
                throw new ValidationException("ERROR");

                
            }
            else
            {
                var ctg = Mapper.Map<CategoryDTO, AccountsCategory>(ctgDTO);
                repo.Edit(ctg);
                return ctg;
            }

        }
        public AccountsCategory DeleteCategory(int id)
        {
            AccountsCategory ctg = repo.GetById(id);
            if (ctg.ID==id) {

                repo.Remove(ctg);

                return ctg;
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