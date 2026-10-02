using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.IO;

namespace cw1_lists.Models
{
    public class NotesRepo
    {
        private List<Note> notes;
        private string filename;
        public NotesRepo()
        {
            
            filename = "notes.json";
            // Load notes from file if it exists, otherwise initialize an empty list
            // Use null-coalescing operator to ensure notes is never null
            notes = File.Exists(filename) ? 
                JsonSerializer.Deserialize<List<Note>>(File.ReadAllText(filename)) 
                ?? new List<Note>() : new List<Note>();
        }
        public void AddNote(Note note)
        {
            notes.Add(note);
        }
        public List<Note> GetAllNotes()
        {
            return notes;
        }

        public int GetLastId()
        {
            return notes.Count > 0 ? notes.Select(n => n.Id).Max() : 0;
        }
        public void SaveNotes()
        {
            File.WriteAllText(filename, JsonSerializer.Serialize(notes));
        }
    }
}
