using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book.Models
{
    public interface IbookRepository
    {
        IQueryable<Books> Books { get; }
    }
}
