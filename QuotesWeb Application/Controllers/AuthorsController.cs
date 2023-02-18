using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuoteWebApp_DataAccess.Repositories.IRepository;
using QuoteWebApp_Models.Models;

namespace QuotesWeb_Application.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorsController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }


        public IActionResult ListAuthors()
        {
            var authors=_authorRepo.ListAuthors();
            return View(authors);
        }

        [Authorize]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorRepo.AddAuthorAsync(author);
                return RedirectToAction(nameof(ListAuthors));
            }
            return View(author);  
        }


        [Authorize]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            if (id == 0 )
            {
                return NotFound();
            }

            var author = await _authorRepo.GetAuthorAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                
                await _authorRepo.UpdateAuthorAsync(author);
                return RedirectToAction(nameof(ListAuthors));
            }
            return View(author);
        }

        [Authorize]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var author = await _authorRepo.GetAuthorAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAuthor(Author author)
        {
            await _authorRepo.DeleteAuthorAsync(author);
            return RedirectToAction(nameof(ListAuthors));
        }


    }
}
