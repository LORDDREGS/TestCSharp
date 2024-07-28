using System.ComponentModel.DataAnnotations;

namespace TestCSharp.Models
{
    public class PlantViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
