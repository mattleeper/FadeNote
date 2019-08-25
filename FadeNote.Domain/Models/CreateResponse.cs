using System;

namespace FadeNote.Domain.Models
{
    /// <summary>
    /// Returned from create method in NoteManager
    /// </summary>
    public class CreateResponse
    {
        public string Id { get; set; }

        public DateTime Expiry {get;set;}

        public bool Success { get; set; }
    }
}
