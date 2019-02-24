using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FadeNote.Web.Models
{
    public class PINViewModel
    {
        public string Id { get; set; }

        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit PIN")]
        public short PIN { get; set; }
    }
}
