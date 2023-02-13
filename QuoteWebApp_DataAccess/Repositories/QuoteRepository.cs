using Microsoft.EntityFrameworkCore;
using QuoteWebApp_DataAccess.Data;
using QuoteWebApp_DataAccess.Repositories.IRepository;
using QuoteWebApp_Models.Models;


namespace QuoteWebApp_DataAccess.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly ApplicationDbContext _db;

        public QuoteRepository(ApplicationDbContext db)
        {
            _db = db;
        }
       
        public async void AddQuote(Quote quote)
        {
            _db.Quotes.Add(quote);
            await _db.SaveChangesAsync();
        }

        public async void DeleteQuote(Quote quote)
        {
            _db.Quotes.Remove(quote);
            await _db.SaveChangesAsync();
        }

        public Quote GetQuoteByAuthor(int autherId)
        {
           return _db.Quotes.FirstOrDefault(x => x.Author.Id == autherId);
        }

        public Quote GetRandomQuote()
        {
            return _db.Quotes.OrderBy(r=> EF.Functions.Random()).FirstOrDefault();
        }

        public IEnumerable<Quote> ListQuotes()
        {
            return _db.Quotes;

        }

        public async void UpdateQuote(Quote quote)
        {
            _db.Quotes.Update(quote);
            await _db.SaveChangesAsync();
        }

    }
}
