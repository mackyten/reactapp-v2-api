using Application.NoteList.Queries;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NoteList.Commands
{
    public class DeleteNote
    {
        public async static Task<bool> DeleteNoteAsync(int noteId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Note postToDelete = await GetNoteById.GetNoteByIdAsync(noteId);

                    db.Remove(postToDelete);

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
