using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using BusinessObject.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class CreateController : Controller
    {
        SendQuery query = new SendQuery();

        [HttpPost("add")]
        public bool CreateProduct([FromForm] CreateProductModel newProduct)
        {
            if (newProduct == null)
            {
                return false;
            }
            query.CreateProduct(newProduct);
            return true;
        }
    }
}
