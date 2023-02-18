using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuoteWebApp_DataAccess.Repositories.IRepository;
using QuoteWebApp_Models.Dtos;
using QuoteWebApp_Models.Models;
using System.Security.Policy;

namespace QuotesWeb_Application.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorsController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }


        // GET: api/authors/listAuthors
        [HttpGet("listAuthors")]
        public IActionResult ListAuthors(int autherId=0)
        {
            return  Ok(_authorRepo.ListAuthors());
        }


        // PUT: api/authors/updateAuthor
        [HttpPut("updateAuthor")]
        public IActionResult UpdateAuthor(UpdateAuthorDto author)
        {
            var newAuth = new Author
            {
                Id=author.Id,
                Name = author.Name
            };
           _authorRepo.UpdateAuthorAsync(newAuth);
           return Ok("Auther has been updated");

        }


        // POST: api/authors/addAuthor
        [HttpPost("addAuthor")]
        public ActionResult<Author> AddAuthor(AddAuthorDto author)
        {
            var newAuth = new Author
            {
                Name = author.Name
            };
            _authorRepo.AddAuthorAsync(newAuth);

            return Ok("Auther has been added");
        }

        // DELETE:  api/authors/deleteAuthor/id
        [HttpDelete("deleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
           
                var author = await _authorRepo.GetAuthorAsync(id);
                if (author == null)
                {
                    return NotFound("Author was not found");
                }
                _authorRepo.DeleteAuthorAsync(author);
                return Ok("Auther has been deleted");  
        }

       
    }
}
