using System;

namespace FadeNote.Domain.Models
{
    public class Note
    {
        /// <summary>
        /// A long complex yet urlencodable identifier. preerably a random base64 string
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The Content of the Note. This should have a characterLimit
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// DateTime note was submitted to the system
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// DateTime when note is set to expire.
        /// </summary>
        public DateTime Expiry { get; set; }

        /// <summary>
        /// A short 4 digit PIN to further obscure the note.
        /// </summary>
        public short PIN { get; set; }

        /// <summary>
        /// The Max allowable reads of a message.
        /// </summary>
        public int MaxReads { get; set; }

        /// <summary>
        /// Current reads of a message
        /// </summary>
        public int CurrentReads { get; set; }
    }
}