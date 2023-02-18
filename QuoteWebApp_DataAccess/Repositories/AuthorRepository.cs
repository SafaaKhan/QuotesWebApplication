using Microsoft.EntityFrameworkCore;
using QuoteWebApp_DataAccess.Data;
using QuoteWebApp_DataAccess.Repositories.IRepository;
using QuoteWebApp_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteWebApp_DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _db;

        public AuthorRepository(ApplicationDbContext db )
        {
            _db = db;
        }

        public async Task AddAuthorAsync(Author author)
        {
            _db.Authors.Add( author );
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            return await _db.Authors.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public IEnumerable<Author> ListAuthors()
        {
             return _db.Authors;
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            var authorDB=await GetAuthorAsync(author.Id);
            authorDB.Name= author.Name;
            await _db.SaveChangesAsync();
        }


    }
}
