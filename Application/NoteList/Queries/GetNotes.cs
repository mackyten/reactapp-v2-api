using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.NoteList.Queries
{
    public class GetNotes
    {

        public async static Task<List<Note>> GetNotesAsync()
        {

            using (var db = new AppDBContext())
            {
                return await db.NotesClean.ToListAsync();

            }
        }


    }
}
