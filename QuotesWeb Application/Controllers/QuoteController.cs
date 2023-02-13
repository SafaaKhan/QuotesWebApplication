using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuoteWebApp_DataAccess.Repositories.IRepository;
using QuoteWebApp_Models.Models;

namespace QuotesWeb_Application.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IQuoteRepository _quoteRepo;

        public QuoteController(IQuoteRepository quoteRepo)
        {
            _quoteRepo = quoteRepo;
        }

        // GET: QuoteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: QuoteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuoteController/Create
        public ActionResult AddQuote()
        {
            return View();
        }

        // POST: QuoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuote(Quote quote)
        {

            _quoteRepo.AddQuote(quote);
            //viewBage message
            return RedirectToAction(nameof(Index));

        }

        // GET: QuoteController/Edit/5
        public ActionResult UpdateQuote(int id)
        {
            return View();
        }

        // POST: QuoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateQuote(Quote quote)
        {
            _quoteRepo.AddQuote(quote);
            //viewBage message
            return RedirectToAction(nameof(Index));
        }

        // GET: QuoteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuoteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
