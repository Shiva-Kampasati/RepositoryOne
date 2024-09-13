using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationOne.Data;
using WebApplicationOne.Model;
using WebApplicationOne.Utils;
using Microsoft.Extensions.Options;

namespace WebApplicationOne.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private  AppDbContext _context;
        private ResponseDTO _responseDTO;
        private JwtOptions _jwtOptions;
     
        public EmployeeController(AppDbContext appDbContext,IOptions<JwtOptions> jwtOptions)
        {
            _context = appDbContext;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            var ss = _jwtOptions;
            _responseDTO = new ResponseDTO();
            _responseDTO.Result = _context.Employee.ToList();
            return _responseDTO;
        }

        [HttpGet]
        [Route("{id}")]
        public ResponseDTO Get(int id)
        {
            _responseDTO = new ResponseDTO();
            _responseDTO.Result = _context.Employee.Where(x => x.Id == id).First();
            return _responseDTO;
        }

        [HttpPost]
        public void Post([FromForm] Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        [HttpDelete]
        //[Route("{id}")]
        public void Delete(int id)
        {
            Employee emp = _context.Employee.First(x => x.Id == id);
            _context.Employee.Remove(emp);
            _context.SaveChanges();
        }
    }
}
