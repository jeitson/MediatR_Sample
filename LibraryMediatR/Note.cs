using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMediatR
{
    public class Note : INote
    {
        private static List<NoteInfo> notes = new List<NoteInfo>();

        public bool Add(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("The note can't be null or empty.");

            notes.Add(new NoteInfo() { Text = text });
            return true;
        }

        public bool Delete(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("The note can't be null or empty.");

            notes.Remove(new NoteInfo() { Text = text });
            return true;
        }

        public List<NoteInfo> List()
        {
            return notes;
        }
    }
}
