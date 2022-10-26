using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBook.App.Api.Models.DTO.Classes
{
    public class MovieByUser
    {
        public string MovieName { get; set; }
        public int GenreId { get; set; }
        public int LanguageId { get; set; }

        public int UserId { get; set; }
    }
}
