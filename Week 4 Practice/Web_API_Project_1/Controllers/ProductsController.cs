using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API_Project_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Http get Request";
        }

        [HttpGet ("Categories")]
        public string GetCategories()
        {
            return "Http get Request for Categories";
        }
        [HttpPost]
        public string Create()
        {
            return "Http post Request";
        }
        [HttpPut("{id}")]
        public string Edit(int id)
        {
            return "Http put Request";

        }
        [HttpDelete("{id}")]
        public string Delete (int id)
        {
            return "Http Delete Request";
        }

    }
}
 