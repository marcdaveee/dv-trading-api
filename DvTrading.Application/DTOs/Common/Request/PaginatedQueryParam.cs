using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvTrading.Application.DTOs.Common.Request
{
    public class PaginatedQueryParam
    {
        public string? SearchTerm {  get; set; }

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public string? SortOrder {  get; set; }
        
        public string? SortBy {  get; set; }
    }
}
