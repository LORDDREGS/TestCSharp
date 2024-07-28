using System.ComponentModel.DataAnnotations;
using TestCSharp.ViewModels; 
using System.Collections.Generic;


namespace TestCSharp.ViewModels
{
    public class PositionViewModel
    {
        public string Id { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string PlantId { get; set; } = string.Empty;

        public List<Plant> Plants { get; set; }

        
        public PositionViewModel()
        {
            Plants = new List<Plant>();
        }
    }
}
