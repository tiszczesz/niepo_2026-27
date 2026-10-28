using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cw1_vm.Models;

public class Student
{
    public int Id { get; set; }
    
    [DisplayName("Imię")]
    [Required(ErrorMessage = "Podaj imię")]
    [MinLength(2,ErrorMessage = "Imię musi mieć conajmniej 2 znaki")]
    public string Firstname { get; set; }
    
    [DisplayName("Nazwisko")]
    [Required(ErrorMessage = "Podaj nazwisko")]
    [MinLength(3,ErrorMessage = "Nazwisko musi mieć conajmniej 3 znaki")]
    public string Lastname { get; set; }
    public int DepartmentId { get; set; }

}
