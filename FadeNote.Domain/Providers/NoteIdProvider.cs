using System;

namespace FadeNote.Domain.Providers
{
    /// <summary>
    /// Generates the Ids for a note
    /// </summary>
    public class NoteIdProvider : INoteIdProvider
    {
        public string New()
        {
            return Guid.NewGuid().ToString();
        }
    }
}