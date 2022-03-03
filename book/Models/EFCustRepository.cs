using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book.Models
{
    public class EFCustRepository : ICustRepository
    {

        private BookstoreContext context;

        public EFCustRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<CustInfo> CustInfo => context.Cust.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveCust(CustInfo custinfo)
        {
            context.AttachRange(custinfo.Lines.Select(x => x.Book));

            if (custinfo.CustId == 0)
            {
                context.Cust.Add(custinfo);
            }

            context.SaveChanges();
        }
    }
}
