using System.ComponentModel.DataAnnotations;

namespace AccountStorage.Pages.Demo
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
