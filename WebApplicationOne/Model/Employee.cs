using System.ComponentModel.DataAnnotations;

namespace WebApplicationOne.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
