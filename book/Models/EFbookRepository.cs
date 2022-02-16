using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book.Models
{
    public class EFbookRepository : IbookRepository
    {
        private BookstoreContext context { get; set; }

        public EFbookRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Books> Books => context.Books;
    }
}
