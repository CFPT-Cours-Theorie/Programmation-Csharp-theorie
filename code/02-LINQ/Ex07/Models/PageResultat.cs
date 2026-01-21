using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07_TakeSkipPagination.Models
{
    internal class PageResultat<T>
    {
        public IEnumerable<T> Elements { get; set; }
        public int PageActuelle { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
    }
}
