using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteWebApp_Models.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public Author Author { get; set; }
    }
}
