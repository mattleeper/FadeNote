using FadeNote.Domain.Models;
using FadeNote.Domain.Providers;
using System;

namespace FadeNote.Domain.Managers
{
    public class NoteManager
    {
        private NoteIdProvider IdProvider { get; set; }

        private IStorageProvider Storage { get; set; }

        public NoteManager()
        {
            IdProvider = new NoteIdProvider();
            Storage = new NoteAppCacheProvider();
        }

        /// <summary>
        /// Adds a new note to storage. will return an id for the note.
        /// </summary>
        /// <returns></returns>
        public CreateResponse Create(Note note)
        {
            note.Id = IdProvider.New();
            note.Created = DateTime.UtcNow;
            note.Expiry = note.Expiry > DateTime.MinValue ? note.Expiry : DateTime.UtcNow.AddHours(1);
            
            return new CreateResponse {
                Id = note.Id,
                Success = Storage.Add(note),
                Expiry = note.Expiry
            };
        }

        /// <summary>
        /// Check for a note and validate pin
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        public (bool, Note) Get(string id, string pin)
        {
            var note = Storage.Retrieve(id);
            var pinRequired = false;
            short.TryParse(pin, out short shortPIN);

            if (note?.PIN > 0 && note.PIN != shortPIN)
            {
                pinRequired = true;
                note = null;
            }
            else
            {
                // Incriment CurrentReads
                if (note?.MaxReads > 0)
                {
                    note.CurrentReads++;

                    if (note.CurrentReads >= note.MaxReads)
                    {
                        Storage.Delete(id);
                    }
                    else
                    {
                        Storage.Update(note);
                    }
                }
            }

            return (pinRequired, note);
        }

        public bool Delete(string id)
        {
            return Storage.Delete(id);
        }
    }
}