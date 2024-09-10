using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationOne.Data;
using WebApplicationOne.Model;
using WebApplicationOne.Utils;

namespace WebApplicationOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private  AppDbContext _context;
        private ResponseDTO _responseDTO;
        public EmployeeController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet]
        public ResponseDTO Get()
        {
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
        public void Post([FromBody] Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Employee emp = _context.Employee.First(x => x.Id==id);
            _context.Employee.Remove(emp);
            _context.SaveChanges();
        }
    }
}
