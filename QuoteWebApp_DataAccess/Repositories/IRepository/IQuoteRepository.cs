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
        Quote GetRandomQuote();
        Quote GetQuoteByAuthor(int autherId);
        void AddQuote(Quote quote);
        void DeleteQuote(Quote quote);
        void UpdateQuote(Quote quote);
        IEnumerable<Quote> ListQuotes();
    }
}
