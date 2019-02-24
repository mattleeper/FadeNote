using FadeNote.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FadeNote.Domain.Providers
{
    public interface IStorageProvider
    {
        /// <summary>
        /// Adds a new note to storage. will return an id for the note.
        /// </summary>
        /// <returns></returns>
        bool Add(Note note);

        /// <summary>
        /// Adds a new note to storage. will return an id for the note.
        /// </summary>
        /// <returns></returns>
        void Update(Note note);

        /// <summary>
        /// Retrieve a note from storage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Note Retrieve(string id);

        /// <summary>
        /// Remove a single item from the cache
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Delete(string id);

        /// <summary>
        /// Clear entire storage
        /// </summary>
        /// <returns></returns>
        bool Clear();
    }
}
