using Application.NoteList.Commands;
using Application.NoteList.Queries;
using Domain;

namespace ReactNoteAPI.Data
{
    public static class NoteRepository
    {

        //Get
        public async static Task<List<Note>> GetNote()
        {
            var result = await GetNotes.GetNotesAsync();
            return result;
        }

        //Get by ID
        public async static Task<Note?> GetNoteByID(int id) {
            var result = await GetNoteById.GetNoteByIdAsync(id);
            if (result == null)
            {
                return null;
            }
            else {
                return result;
            }
            
        }

        //create
        public async static Task<bool> CreateNewNote(Note note) {
            var result = await CreateNote.CreateNoteAsync(note);
            return result;
        }

        //update
        public async static Task<bool> Update(Note note) {

            bool result = await UpdateNote.UpdateNoteAsync(note);
            return result;
        }

        //delete
        public async static Task<bool> Delete(int noteId) {
            var result = await DeleteNote.DeleteNoteAsync(noteId);
            return result;
        }
    }
}
