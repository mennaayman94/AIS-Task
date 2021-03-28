using System.Web.Http;
using WebApplication1.Business_Layer;
using WebApplication1.Models;
using WebApplication1.RepoImp;

namespace WebApplication1.Controllers
{
    public class CategoryController : ApiController

    {
        Repository<AccountsCategory> repo = new Repository<AccountsCategory>(new Accounts_DBEntities());
        //private Accounts_DBEntities db = new Accounts_DBEntities();
        CategoryBL CatBL = new CategoryBL();
        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            try
            {
                var GetCategoty = CatBL.GetCategories();
                return Ok(GetCategoty);
            }
            catch
            {
                return BadRequest("There is an error ");
            }
        }
        

        [HttpPost]
        public IHttpActionResult CreateCategories(AddCategoryDTO ctgDTO)
        {
            try
            {
                var CreatedCategory = CatBL.CreateCategory(ctgDTO);
                return Ok(CreatedCategory);
            }
            catch
            {
               return BadRequest("There is an error ");
            }
        }
        [HttpPut]
        public IHttpActionResult EditCategory(int id, CategoryDTO ctgDTO)
        {
            if (ctgDTO.ID == id) {
                var EditedCategory = CatBL.PutCategory(ctgDTO);

                return Ok(EditedCategory);
            }
            else {
                return BadRequest("This Id is Not Found");
                }
            
            
        }
        [HttpDelete]
        public IHttpActionResult DeleteCategories(int id)
        {
            try
            {
                var DeletedCategory = CatBL.DeleteCategory(id);

                return Ok(DeletedCategory);
            }
            catch
            {
                return BadRequest("There is an error");

            }
        }
    }
}
