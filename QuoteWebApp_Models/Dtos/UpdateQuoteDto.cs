using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteWebApp_Models.Dtos
{
    public class UpdateQuoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
