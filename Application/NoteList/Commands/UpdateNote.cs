using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NoteList.Commands
{
    public class UpdateNote
    {
        public async static Task<bool> UpdateNoteAsync(Note noteToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
             
                    db.Notes.Update(noteToUpdate);
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
