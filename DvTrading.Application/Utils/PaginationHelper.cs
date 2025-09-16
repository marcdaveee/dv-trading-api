using DvTrading.Application.DTOs.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvTrading.Application.Utils
{
    public static class PaginationHelper<T>
    {
        public static PaginatedResponseDto<T> CreatePagedResult(List<T> items, int pageNumber, int pageSize, int totalPages, int pageCount)
        {
            return new PaginatedResponseDto<T>
            {
                Items = new List<T>(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalCount = pageCount
            };
        }
    }
}
