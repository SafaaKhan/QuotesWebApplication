using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuoteWebApp_DataAccess.Data;
using QuoteWebApp_DataAccess.Repositories.IRepository;
using QuoteWebApp_Models.Models;
using System.Net.Http;

namespace QuoteWebApp_DataAccess.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly HttpClient _httpClient;

        public QuoteRepository(ApplicationDbContext db, HttpClient httpClient)
        {
            _db = db;
            _httpClient= httpClient;
        }
       
        public async Task AddQuoteAsync(Quote quote)
        {
            _db.Quotes.Add(quote);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteQuoteAsync(Quote quote)
        {
            _db.Quotes.Remove(quote);
            await _db.SaveChangesAsync();
        }

        public Quote GetQuoteByAuthor(int autherId)
        {
           return _db.Quotes.FirstOrDefault(x => x.Author.Id == autherId);
        }

        public async Task<Quote> GetQuoteByIdAsync(int id)
        {
            return await _db.Quotes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Quote GetRandomQuote()
        {
            Random rand = new Random();
            int toSkip = rand.Next(1, _db.Quotes.Count());
            Quote quote=(Quote)_db.Quotes.OrderBy(x => x.Id).Skip(toSkip).Take(1).FirstOrDefault();
            return quote;
        }

        public async Task<Quote> GetRandomQuoteFROMAPI()
        {
            var response = await _httpClient.GetAsync($"/api/quoteAPI/getRandomQuote");
            var apiContect = await response.Content.ReadAsStringAsync();
            var quote = JsonConvert.DeserializeObject<Quote>(Convert.ToString(apiContect));
            return quote;
        }

        public IEnumerable<Quote> ListQuotes(int autherId)
        {
           var quotes= autherId==0 ?  _db.Quotes:  _db.Quotes.Where(x => x.AuthorId == autherId);
            return quotes;

        }

        public async Task UpdateQuoteAsync(Quote quote)
        {
            var quoteDb = await GetQuoteByIdAsync(quote.Id);
            quoteDb.Text = quote.Text;
            quoteDb.AuthorId = quote.AuthorId;
            await _db.SaveChangesAsync();
        }

    }
}
