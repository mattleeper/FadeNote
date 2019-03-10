using System;
using System.ComponentModel.DataAnnotations;

namespace FadeNote.Web.Models
{
    public class NewNoteViewModel
    {

        [Display(Name = "Note", Prompt = "note content")]
        public string Content { get; set; }

        public DateTime Expiry { get; set; } = DateTime.UtcNow.AddHours(1);

        [Display(Prompt = "PIN (optional)")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit PIN")]
        public short PIN { get; set; }

        public int MaxReads { get; set; } = 1;
    }
}