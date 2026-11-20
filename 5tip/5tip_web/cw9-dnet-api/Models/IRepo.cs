using System;

namespace cw9_dnet_api.Models;

public interface IRepo
{
    public List<Sudent> GetAll();
    Sudent? GetById(int id);
}
