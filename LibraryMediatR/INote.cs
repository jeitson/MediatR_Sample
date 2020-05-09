using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMediatR
{
    public interface INote
    {
        bool Add(string text);
        bool Delete(string text);
        List<NoteInfo> List();
    }
}
