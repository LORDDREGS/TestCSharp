using System.ComponentModel.DataAnnotations;

namespace TestCSharp.Models
{
    public class DepartmentViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }

        [Display(Name = "Is Auditor")]
        public bool IsAuditor { get; set; }

        [Required]
        [Display(Name = "Plant")]
        public string PlantId { get; set; }

        public IEnumerable<PlantViewModel> Plants { get; set; }
    }
}
