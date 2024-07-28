using TestCSharp.ViewModels;

namespace TestCSharp.ViewModels

{
    public class PositionViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string DepartmentId { get; set; } = string.Empty;
        public string PlantId { get; set; } = string.Empty;

        public IEnumerable<Department> Departments { get; set; } = new List<Department>();
        public IEnumerable<Plant> Plants { get; set; } = new List<Plant>();
    }
}
