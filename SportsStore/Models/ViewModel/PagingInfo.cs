using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModel
{
    public class PagingInfo
    {
        public int Total { get; set; }
        public int PerPage { get; set; }
        public int Current { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)Total / PerPage);
    }
}
