using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuoteWebApp_DataAccess.Repositories.IRepository;
using QuoteWebApp_Models.Models;

namespace QuotesWeb_Application.Controllers
{
    public class QuotesController : Controller
    {
        private readonly IQuoteRepository _quoteRepo;
        private readonly IAuthorRepository _authorRepo;
        
        public QuotesController(IQuoteRepository quoteRepo, 
            IAuthorRepository authorRepo )
        {
            _quoteRepo = quoteRepo;
            _authorRepo = authorRepo;
        }

        public ActionResult ListQuotes(int SearchString=0,int authorId =0)
        {
            var listQuotes = _quoteRepo.ListQuotes(authorId);
            if (SearchString != 0)
            {
                listQuotes = _quoteRepo.ListQuotes(SearchString);
            }
            
            ViewData["AuthorId"] = new SelectList(_authorRepo.ListAuthors(), "Id", "Name");
            return View(listQuotes);
        }

        public async Task<ActionResult> GetRandomQuote()
        {
            //httpClient has been used in the repository
            var quote = await _quoteRepo.GetRandomQuoteFROMAPI();
             List<Quote> quotes = new List<Quote>();
            quotes.Add(quote);
            ViewData["AuthorId"] = new SelectList(_authorRepo.ListAuthors(), "Id", "Name");
            return View(nameof(ListQuotes), quotes);
        }


        [Authorize]
        public ActionResult AddQuote()
        {
            ViewData["AuthorId"] = new SelectList(_authorRepo.ListAuthors(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddQuote(Quote quote)
        {

            await _quoteRepo.AddQuoteAsync(quote);
            //viewBage message
            ViewData["AuthorId"] = new SelectList(_authorRepo.ListAuthors(), "Id", "Name");
            return RedirectToAction(nameof(ListQuotes));

        }


        [Authorize]
        public async Task<ActionResult> UpdateQuote(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var quote = await _quoteRepo.GetQuoteByIdAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_authorRepo.ListAuthors(), "Id", "Name", quote.AuthorId);
            return View(quote);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateQuote(Quote quote)
        {
            await _quoteRepo.UpdateQuoteAsync(quote);
            //viewBage message
            ViewData["AuthorId"] = new SelectList(_authorRepo.ListAuthors(), "Id", "Name");
            return RedirectToAction(nameof(ListQuotes));
        }

        [Authorize]
        public async Task<ActionResult> DeleteQuote(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var quote = await _quoteRepo.GetQuoteByIdAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            return View(quote);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteQuote(Quote quote)
        {
            await _quoteRepo.DeleteQuoteAsync(quote);
            //viewBage message
            ViewData["AuthorId"] = new SelectList(_authorRepo.ListAuthors(), "Id", "Name");
            return RedirectToAction(nameof(ListQuotes));
        }
    }
}
