using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.NoteList.Queries
{
    public class GetNoteById
    {
        public async static Task<Note> GetNoteByIdAsync(int noteID)
        {

            using (var db = new AppDBContext())
            {
                return await db.Notes.FirstOrDefaultAsync(note => note.Id == noteID);
            }
        }
    }
}
