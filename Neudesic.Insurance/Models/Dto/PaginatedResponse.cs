using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neudesic.Insurance.Models.Dto
{
    public class PaginatedResponse<T>
    {
        public IEnumerable<T> CurrentPageData { get; set; }
        public int PageNumber { get; set; }
        public int TotalNumberOfRecords { get; set; }
    }
}
