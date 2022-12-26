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
        public async static Task<bool> DeleteNoteAsync(int noteId, string currentUserEmail)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Note postToDelete = await GetNoteById.GetNoteByIdAsync(noteId);

                    if (currentUserEmail == postToDelete.Owner) {
                        db.Remove(postToDelete);

                        return await db.SaveChangesAsync() >= 1;
                    } else { 
                        return false;
                    }

                    
                 

                    
                }
                catch (Exception)
                {

                    return false;
                }
            }

        }
    }
}
