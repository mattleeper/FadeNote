using System;

namespace FadeNote.Web.Models
{
    public class NoteViewModel
    {
        public string Content { get; set; }

        public DateTime Expiry { get; set; }

        public int ReadsLeft { get; set; }

        public bool Deleted { get; set; }
    }
}