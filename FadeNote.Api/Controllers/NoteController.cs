using FadeNote.Api.Models;
using FadeNote.Domain.Managers;
using FadeNote.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FadeNote.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private NoteManager noteManager;

        public NoteController()
        {
            noteManager = new NoteManager();
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]string id, [FromQuery]string PIN )
        {
            (var pinRequired, var dataModel) = noteManager.Get(id, PIN);

            if (!pinRequired && dataModel != null)
            {
                return Ok(new NoteViewModel
                {
                    Content = dataModel.Content,
                    Expiry = dataModel.Expiry,
                    MaxReads = dataModel.MaxReads,
                    CurrentReads = dataModel.CurrentReads
                });
            }
            
             return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]NoteViewModel model)
        {
            var dataModel = new Note
            {
                Content = model.Content,
                Expiry = model.Expiry,
                PIN = model.PIN,
                MaxReads = model.MaxReads,
            };

            var response = noteManager.Create(dataModel);

            if (response?.Success ?? false && !string.IsNullOrEmpty(response?.Id))
            {
                return Ok(new { response.Id });
            }

            return BadRequest();
        }
    }
}