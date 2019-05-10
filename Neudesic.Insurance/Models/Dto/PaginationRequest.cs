using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.Dto
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; }
        public int RecordsPerPage { get; set; }
    }
}
