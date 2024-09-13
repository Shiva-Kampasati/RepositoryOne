using System.ComponentModel.DataAnnotations;

namespace WebApplicationOne.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
