using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book.Models
{
    public interface ICustRepository
    {
        public IQueryable<CustInfo> CustInfo { get; }

        public void SaveCust(CustInfo cust);
    }
}
