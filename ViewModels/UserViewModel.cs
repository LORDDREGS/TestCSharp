using System.Collections.Generic;
using TestCSharp.Models;

public class UserViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string Middlename { get; set; } = string.Empty;
    public string Plant { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
     
    public List<Plant> Plants { get; set; }  
    public List<Department> Departments { get; set; }
    public List<Position> Positions { get; set; }

    public UserViewModel()
        {
            Plants = new List<Plant>();
            Departments = new List<Department>();
            Positions = new List<Position>();
        }

}
