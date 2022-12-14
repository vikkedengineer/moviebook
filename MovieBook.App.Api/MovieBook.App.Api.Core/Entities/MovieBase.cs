using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBook.App.Api.Core.Entities
{
    public class MovieBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId  { get; set; }
        public int LanguageId { get; set; }
        public int Rating { get; set; }
    }
}
