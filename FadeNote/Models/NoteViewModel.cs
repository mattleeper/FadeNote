using System;
using System.ComponentModel.DataAnnotations;

namespace FadeNote.Web.Models
{
    public class NoteViewModel
    {
        [Display(Name ="Note Content")]
        public string Content { get; set; }

        public DateTime Expiry { get; set; }

        public int ReadsLeft { get; set; }

        public bool Deleted { get; set; }
    }
}