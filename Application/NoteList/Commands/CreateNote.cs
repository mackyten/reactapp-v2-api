using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.NoteList.Commands
{
    public class CreateNote
    {
        public async static Task<bool> CreateNoteAsync(Note noteToCreate)
        {

            using (var db = new AppDBContext())
            {

                try
                {
                    await db.NotesClean.AddAsync(noteToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
