using System;

namespace cw9_dnet_api.Models;

public class Sudent
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int Age { get; set; }
    public string? Description { get; set; }
}
