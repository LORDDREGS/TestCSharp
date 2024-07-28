using System.ComponentModel.DataAnnotations;
using TestCSharp.ViewModels; 

namespace TestCSharp.ViewModels
{
    public class PlantViewModel
    {
        public string Id { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        
        public PlantViewModel()
        {
        }
    }
}
