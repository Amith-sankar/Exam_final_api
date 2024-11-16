using DemoApp.Data;
using DemoApp.Model.DTO;
using DemoApp.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

         public LoginController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<DemoTable1>>> GetDetails()
        {
            return await dBContext.Demo_Table_Login.ToListAsync();
        }

        [HttpPost]
        public IActionResult createForDemoTable1(DemoTable1Dto demoTable1Data)
        {
            var createDemoTable1Data = new DemoTable1()
            {
                Name = demoTable1Data.Name,
                EmailId = demoTable1Data.Email,
                Password = demoTable1Data.Password,

            };

            dBContext.Demo_Table_Login.Add(createDemoTable1Data);
            dBContext.SaveChanges();
            return Ok(createDemoTable1Data);
        }

        [HttpPost]

        public IActionResult checkAlreadyHaveEntry (DemoTable1Dto demoTable1Data)
        {
            var user = dBContext.Demo_Table_Login.Where(x => x.Name == demoTable1Data.Name).FirstOrDefault();
            if (user != null)
            {
                return Ok(new
                {
                    id = 1, name = user.Name
                });
            }else
            {
                return Ok(new
                {
                    id = 0,
                    message="Invalid User"
                });
            }
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var allStudents = dBContext.students.ToList();
            return Ok(allStudents);
        }

        [HttpPost("AddStudent")]

        public IActionResult AddStudent(AddStudent addStudentDto)
        {
            var studentEntity = new Student()
            {
                Name = addStudentDto.Name,
                Email = addStudentDto.Email
            };

            dBContext.students.Add(studentEntity);
            dBContext.SaveChanges();
            return Ok(studentEntity);
        }



    }
}
