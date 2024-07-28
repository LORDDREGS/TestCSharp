using System.Collections.Generic;
using TestCSharp.Models;

namespace TestCSharp.ViewModels
{
    public class DepartmentViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public bool IsAuditor { get; set; }
        public string PlantId { get; set; } = string.Empty;

        
        public List<Plant> Plants { get; set; } = new List<Plant>();

        // Default constructor
        public DepartmentViewModel()
        {
        }
    }
}
