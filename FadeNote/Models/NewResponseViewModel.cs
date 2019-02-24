using System;

namespace FadeNote.Web.Models
{
    public class NewResponseViewModel
    {
        public string Id { get; set; }

        public string Message { get; set; }

        public string URL { get; set; }

        public DateTime Expiry { get; set; }

        public int MaxReads { get; set; }
    }
}