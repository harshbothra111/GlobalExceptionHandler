using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Policy
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
