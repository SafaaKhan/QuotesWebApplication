using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuoteWebApp_DataAccess.Repositories.IRepository;
using QuoteWebApp_Models.Models;

namespace QuotesWeb_Application.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IQuoteRepository _quoteRepo;
        private readonly IAuthorRepository _authorRepo;

        public QuoteController(IQuoteRepository quoteRepo, IAuthorRepository authorRepo)
        {
            _quoteRepo = quoteRepo;
            _authorRepo = authorRepo;
        }

        public ActionResult ListQuotes(int authorId=0)
        {
            var listQuotes= _quoteRepo.ListQuotes(authorId);
            return View(listQuotes);
        }

        //public ActionResult GetRandomQuote()
        //{
        //   var quote= _quoteRepo.GetRandomQuote();
        //   return View(quote);
        //}

       
        public ActionResult AddQuote()
        {
           // ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuote(Quote quote)
        {

            _quoteRepo.AddQuote(quote);
            //viewBage message
            return RedirectToAction(nameof(ListQuotes));

        }

        public ActionResult UpdateQuote(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateQuote(Quote quote)
        {
            _quoteRepo.UpdateQuote(quote);
            //viewBage message
            return RedirectToAction(nameof(ListQuotes));
        }


        public ActionResult DeleteQuote(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteQuote(Quote quote)
        {
            _quoteRepo.DeleteQuote(quote);
            //viewBage message
            return RedirectToAction(nameof(ListQuotes));
        }
    }
}
