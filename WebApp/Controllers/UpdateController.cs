using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;
using BusinessLogic;
using Microsoft.AspNetCore.Http;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        SendQuery query = new SendQuery();

        [HttpPost("update")]
        public bool UpdateProduct([FromForm] UpdateProductModel editProduct)
        {
            if (editProduct == null)
            {
                return false;
            }
            query.UpdateProduct(editProduct);
            AddIdInCookies(editProduct.Id);


            return true;
        }

        [HttpGet("list")]
        public List<IndexProductForListModel> ListOfProduct()
        {
            var List = query.GetListProducts();
            return List;
        }

        private void AddIdInCookies(int id)
        {
            var cookieOptions = new CookieOptions
            {
                Secure = true,

                HttpOnly = true,

                SameSite = SameSiteMode.None
            };

            Response.Cookies.Append("UpdateProductId", id.ToString(), cookieOptions);
        }
    }
}