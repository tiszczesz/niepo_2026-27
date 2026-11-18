using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cw1_vm.Models;

public class Department
{
    public int Id { get; set; }
    
    [DisplayName("Nazwa klasy")]
    [Required(ErrorMessage = "Musisz podać nazwę")]
    [MinLength(2,ErrorMessage = "Minimum 2 litery")]
    public string Name { get; set; }
    
    [DisplayName("Opis klasy")]
    [Required(ErrorMessage = "Musisz podać opis")]
    public string Description { get; set; }
}
