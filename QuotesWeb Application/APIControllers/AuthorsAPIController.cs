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
    public class AuthorsAPIController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorsAPIController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }


        // GET: api/authorsAPI/listAuthors
        [HttpGet("listAuthors")]
        public IActionResult ListAuthors(int autherId=0)
        {
            return  Ok(_authorRepo.ListAuthors());
        }


        // PUT: api/authorsAPI/updateAuthor
        [HttpPut("updateAuthor")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto author)
        {
            var newAuth = new Author
            {
                Id=author.Id,
                Name = author.Name
            };
           await _authorRepo.UpdateAuthorAsync(newAuth);
           return Ok("Auther has been updated");

        }


        // POST: api/authorsAPI/addAuthor
        [HttpPost("addAuthor")]
        public async Task<ActionResult> AddAuthor(AddAuthorDto author)
        {
            var newAuth = new Author
            {
                Name = author.Name
            };
            await _authorRepo.AddAuthorAsync(newAuth);

            return Ok("Auther has been added");
        }

        // DELETE:  api/authorsAPI/deleteAuthor/id
        [HttpDelete("deleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
           
                var author = await _authorRepo.GetAuthorAsync(id);
                if (author == null)
                {
                    return NotFound("Author was not found");
                }
                await _authorRepo.DeleteAuthorAsync(author);
                return Ok("Auther has been deleted");  
        }

       
    }
}
