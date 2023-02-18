using QuoteWebApp_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteWebApp_DataAccess.Repositories.IRepository
{
    public interface IAuthorRepository
    {
        Task<Author> GetAuthorAsync(int id);
        Task AddAuthorAsync(Author author);
        Task DeleteAuthorAsync(Author author);
        Task UpdateAuthorAsync(Author author);
        IEnumerable<Author> ListAuthors();
    }
}
