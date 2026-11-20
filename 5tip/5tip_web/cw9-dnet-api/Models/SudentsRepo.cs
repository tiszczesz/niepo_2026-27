using System;
using Microsoft.Data.Sqlite;

namespace cw9_dnet_api.Models;

public class SudentsRepo : IRepo
{
    private string connString="";
    public SudentsRepo(string conn)
    {
        connString = conn;        
    }
    public List<Sudent> GetAll()
    {
        using SqliteConnection conn = new SqliteConnection(connString);
        using SqliteCommand command = conn.CreateCommand();
        command.CommandText = "SELECT * FROM Sudents";
        conn.Open();
        List<Sudent> sudents = new();
        SqliteDataReader rd = command.ExecuteReader();
        while (rd.Read())
        {
            sudents.Add(
                new Sudent
                {
                    Id = rd.GetInt32(0),
                    Firstname = rd.GetString(1),
                    Lastname = rd.GetString(2),
                    Age = rd.GetInt32(3),
                    Description = rd.GetString(4)
                }
            );
        }
        return sudents;
    }

    public Sudent? GetById(int id)
    {
        return null;
    }


}
