﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuoteWebApp_DataAccess.Repositories.IRepository;
using QuoteWebApp_Models.Dtos;
using QuoteWebApp_Models.Models;

namespace QuotesWeb_Application.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesAPIController : ControllerBase
    {
        private readonly IQuoteRepository _quoteRepo;
        private readonly IAuthorRepository _authorRepo;
        public QuotesAPIController(IQuoteRepository quoteRepo, IAuthorRepository authorRepo)
        {
            _quoteRepo= quoteRepo;
            _authorRepo= authorRepo;
        }



        // GET: api/quotesAPI/getRandomQuote
        [HttpGet("getRandomQuote")]
        public IActionResult GetRandomQuote(int id)
        {
            try
            {
                return Ok(_quoteRepo.GetRandomQuote());

            }
            catch
            {
                return BadRequest("Something error happened");
            }
        }

        // GET: api/quotesAPI/getQuoteByAuthor
        [HttpGet("getQuoteByAuthor")]
        public IActionResult GetQuoteByAuthor(int id)//authorId
        {
            try
            {
                return Ok(_quoteRepo.GetQuoteByAuthor(id));
            }
            catch
            {
                return BadRequest("Something error happened");
            }
        }

        // GET: api/quotesAPI/listQuotes
        [HttpGet("listQuotes")]
        public IActionResult ListQuotes(int authorId)
        {
            try
            {
                return Ok(_quoteRepo.ListQuotes(authorId));

            }
            catch
            {
                return BadRequest("Something error happened");
            }
        }



        // PUT: api/quotesAPI/updateQuote
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("updateQuote")]
        public async Task<IActionResult> UpdateQuote( UpdateQuoteDto quote)
        {
            try
            {
                var newQuote = new Quote
                {
                    Id = quote.Id,
                    Text = quote.Text,
                    AuthorId = quote.AuthorId
                };
                await _quoteRepo.UpdateQuoteAsync(newQuote);
                return Ok("Quote has been updated");
            }
            catch
            {
                return BadRequest("Something error happened");
            }
           
        }

        // POST: api/quotesAPI/addQuote
        [HttpPost("addQuote")]
        public async Task<ActionResult> AddQuote(AddQuoteDto quote)
        {
            try
            {
                var newQuote = new Quote
                {
                    Text = quote.Text,
                    AuthorId = quote.AuthorId
                };
                await _quoteRepo.AddQuoteAsync(newQuote);

                return Ok("Quote has been added");
            }
            catch
            {
                return BadRequest("Something error happened");
            }
            
        }

        // DELETE: api/quotesAPI/deleteQuote
        [HttpDelete("deleteQuote/{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            try
            {
                var quote = await _quoteRepo.GetQuoteByIdAsync(id);
                if (quote == null)
                {
                    return NotFound("Quote was not found");
                }
                await _quoteRepo.DeleteQuoteAsync(quote);
                return Ok("Quote has been deleted");
            }
            catch
            {
                return BadRequest("Something error happened");
            }
           
        }

    }
}
