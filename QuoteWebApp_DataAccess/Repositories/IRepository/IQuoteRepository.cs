using QuoteWebApp_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteWebApp_DataAccess.Repositories.IRepository
{
    public interface IQuoteRepository
    {
        Task<Quote> GetRandomQuoteFROMAPI();
        Task<Quote> GetQuoteByIdAsync(int id);
        Quote GetRandomQuote();
        Quote GetQuoteByAuthor(int autherId);
        Task AddQuoteAsync(Quote quote);
        Task DeleteQuoteAsync(Quote quote);
        Task UpdateQuoteAsync(Quote quote);
        IEnumerable<Quote> ListQuotes(int autherId);
    }
}
