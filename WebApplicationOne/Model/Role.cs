using System.ComponentModel.DataAnnotations;

namespace WebApplicationOne.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
