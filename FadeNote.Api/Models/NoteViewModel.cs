using Newtonsoft.Json;
using System;

namespace FadeNote.Api.Models
{
    public class NoteViewModel
    {
        public string Content { get; set; }

        public DateTime Expiry { get; set; }

        public short PIN { get; set; }

        public int MaxReads { get; set; } = 1;

        public int CurrentReads { get; set; } = 1;
    }
}
