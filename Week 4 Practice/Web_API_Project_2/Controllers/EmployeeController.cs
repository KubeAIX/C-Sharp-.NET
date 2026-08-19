using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Project_2.Models;

namespace Web_API_Project_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //create
        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Employe Created");
        }

        //Read
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Get All Employees");

        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id)
        {
            return Ok($"Employee {id} updated");
        }

        // DELETE
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok($"Employee {id} deleted");
        }

    }
}
