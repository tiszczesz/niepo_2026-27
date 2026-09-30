using System;
using cw1_vm.Models.ViewModels;
using MySqlConnector;

namespace cw1_vm.Models;

public class SchoolRepo
{
    private string _connectionString;
    public SchoolRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("mysql")
        ??"server=localhost;database=3tip_2026_school;user=root;password=;";
    }
    public List<StudentDepartmentVM> GetStudentsWithDepartments()
    {
        using var connection = new MySqlConnection(_connectionString);
        using var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT s.id, s.firstname, s.lastname, s.department_id, 
            d.id AS DepartmentId, d.name, d.description 
            FROM Students s JOIN Departments d ON s.department_id = d.id;";
        
    }

}
