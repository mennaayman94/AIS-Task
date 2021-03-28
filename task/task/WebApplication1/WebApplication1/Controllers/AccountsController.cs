using System;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Business_Layer;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountsController : ApiController
    {

        //Repository<Account> repo = new Repository<Account>(new Accounts_DBEntities());
        //private Accounts_DBEntities db = new Accounts_DBEntities();
        AccountBL AccBl = new AccountBL();

        [HttpGet]
        public IHttpActionResult GetAllAccounts()
        {
            try
            {
                var GetAcc = AccBl.GetAccounts();
                return Ok(GetAcc);
            }
            catch
            {
                return BadRequest("There is An Error");
            }
            
           
        }
        [HttpPost]
        public IHttpActionResult AddAcount(AddAcountDTO ACC)
        {
           
                    var CreatedAcc = AccBl.CreateAccount(ACC);
                    return Ok(CreatedAcc);
                

            
        }
        [HttpPut]
        public IHttpActionResult EditAccount(int id,AccountDTO acc)
        {
            if (acc.ID != id)
            {
                return BadRequest("This Id is Not Found");
            }
            else
            {
                var EditedAcc = AccBl.PutAccount(acc);
                return Ok(EditedAcc);
            }
        }
        [HttpDelete]
        public IHttpActionResult DeleteAccounts(int id)
        {
            try
            {
                var DeletedAcc = AccBl.DeleteAccount(id);
                return Ok(DeletedAcc);
            }
            catch
            {
                return BadRequest("There is an Error");
            }
        }
     
    }
}
