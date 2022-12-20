using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactNoteAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        // GET: api/<NotesController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var result = await NoteRepository.GetNote();
            return Ok(result);
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await NoteRepository.GetNoteByID(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        // POST api/<NotesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Note note)
        {
            var result = await NoteRepository.CreateNewNote(note);

            if (result == true)
            {
                return Ok(note);
            }
            else
            {

                return BadRequest();
            }

        }

        // PUT api/<NotesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Note note)
        {
            bool result = await NoteRepository.Update(note);
            if (result)
            {
                return Ok(note);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await NoteRepository.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
