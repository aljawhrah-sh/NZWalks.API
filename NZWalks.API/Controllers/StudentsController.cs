using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentsList = new string[] { "a", "b", "c" };
            return Ok(studentsList);
        }
    }
}

