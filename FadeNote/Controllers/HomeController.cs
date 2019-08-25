using FadeNote.Domain.Managers;
using FadeNote.Domain.Models;
using FadeNote.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FadeNote.Web.Controllers
{
    public class HomeController : Controller
    {
        private NoteManager manager { get; set; }

        public HomeController()
        {
            manager = new NoteManager();
        }

        #region Page

        /// <summary>
        /// Home page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Create and share volatile notes. Perfect for secrets and keys.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion Page

        #region Note
        
        /// <summary>
        /// Used for creating a new note. 
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Note(NewNoteViewModel note)
        {
            if (note != null)
            {
                var dataNote = new Note
                {
                    Expiry = note.Expiry > DateTime.MinValue ? note.Expiry : DateTime.UtcNow.AddHours(1),
                    Content = note.Content,
                    MaxReads = note.MaxReads,
                    PIN = note.PIN
                };

                var newNoteId = manager.Create(dataNote);

                if (!string.IsNullOrWhiteSpace(newNoteId))
                {
                    string message = string.Format("Your FadeNote has been created. It will expire at {0} or when it is read {1} times. Which ever happens first.", note.Expiry, note.MaxReads);

                    var response = new NewResponseViewModel()
                    {
                        Id = newNoteId,
                        Message = message,
                        URL = Url.Link("Note", new { Id = newNoteId }),
                        Expiry = dataNote.Expiry,
                        MaxReads = note.MaxReads,
                    };

                    return View("Success", response);
                }
            }

            return View("Index");
        }

        /// <summary>
        /// Used for retrieving an existing note. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Note(string id, string pin)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                (var pinRequired, var dataModel) = manager.Get(id, pin);

                if (pinRequired)
                {
                    return View("pin", new PINViewModel { Id = id });
                }

                if (dataModel != null)
                {
                    var viewModel = new NoteViewModel
                    {
                        Content = dataModel.Content,
                        Deleted = dataModel.MaxReads > 0 && dataModel.CurrentReads >= dataModel.MaxReads,
                        ReadsLeft = dataModel.MaxReads - dataModel.CurrentReads,
                        Expiry = dataModel.Expiry
                    };
                    return View(viewModel);
                }
            }

            return View("NotFound");
        }

        #endregion Note
    }
}