using System.ComponentModel.DataAnnotations;

namespace TestCSharp.Models
{
    public class PositionViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Plant")]
        public string PlantId { get; set; }

        public IEnumerable<PlantViewModel> Plants { get; set; }
    }
}
