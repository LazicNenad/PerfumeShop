using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.UseCases.Queries
{
    public class PagedResponse<T> 
        where T : class
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount => (int)Math.Ceiling((float)TotalCount / ItemsPerPage);
        public IEnumerable<T> Data { get; set; }

    }
}
