using FadeNote.Domain.Models;
using System.Runtime.Caching;

namespace FadeNote.Domain.Providers
{
    /// <summary>
    /// Stores and retreives notes from memory using app cache.
    /// </summary>
    public class NoteAppCacheProvider : IStorageProvider
    {
        private MemoryCache cache;

        public NoteAppCacheProvider()
        {
            cache = MemoryCache.Default;
        }

        /// <summary>
        /// Adds a new note to storage. will return an id for the note.
        /// </summary>
        /// <returns></returns>
        public bool Add(Note note)
        {
            return cache.Add(note.Id, note, note.Expiry);
        }

        /// <summary>
        /// Adds a new note to storage. will return an id for the note.
        /// </summary>
        /// <returns></returns>
        public void Update(Note note)
        {
            cache.Set(note.Id, note, note.Expiry);
        }

        /// <summary>
        /// Retrieve a note from memory cache
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Note Retrieve(string id)
        {
            return cache.Get(id) as Note;
        }

        /// <summary>
        /// Remove a single item from the cache
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return cache.Remove(id) != null;
        }

        /// <summary>
        /// Clear entire cache
        /// </summary>
        /// <returns></returns>
        public bool Clear()
        {
            return cache.Trim(100) >= 100;
        }
    }
}