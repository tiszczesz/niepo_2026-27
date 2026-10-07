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
        connection.Open();
        command.CommandText = @"
            SELECT s.id, s.firstname, s.lastname, s.department_id, 
            d.id AS DepartmentId, d.name, d.description 
            FROM Students s JOIN Departments d ON s.department_id = d.id;";
        using var reader = command.ExecuteReader();
        var students = new List<StudentDepartmentVM>();
        while (reader.Read())
        {
            students.Add(new StudentDepartmentVM
            {
                Student = new Student
                {
                    Id = reader.GetInt32("id"),
                    Firstname = reader.GetString("firstname"),
                    Lastname = reader.GetString("lastname"),
                    DepartmentId = reader.GetInt32("department_id")
                },
                Department = new Department
                {
                    Id = reader.GetInt32("DepartmentId"),
                    Name = reader.GetString("name"),
                    Description = reader.GetString("description")
                }
            });
        }
        return students;
    }
    public List<DepartmentsStudent> GetDepartmentStudent()
    {
        using var connection = new MySqlConnection(_connectionString);
        using var command = connection.CreateCommand();
        connection.Open();
        List<DepartmentsStudent> deps = new List<DepartmentsStudent>();
        //wypełnianie listy
       command.CommandText = @"
            SELECT d.id, d.name, d.description, COUNT(s.id) AS StudentCount
            FROM Departments d
            LEFT JOIN Students s ON d.id = s.department_id
            GROUP BY d.id, d.name, d.description;";

        return deps;
    }

}

  


