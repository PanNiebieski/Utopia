using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationPlus.Core.CQRS.Territory.Queries.GetAllTerriotries
{
    public record GetAllTerriotiesQuery(OrderByTerritoryOptions OrderBy,
         int Page, int PageSize)
    {
        private const int DefaultPage = 1;
        private const int DefaultPageSize = 3;

        public static GetAllTerriotiesQuery With(OrderByTerritoryOptions? filter, int? page, int? pageSize)
        {
            page ??= DefaultPage;
            pageSize ??= DefaultPageSize;

            filter ??= OrderByTerritoryOptions.None;

            if (page <= 0)
                throw new ArgumentOutOfRangeException(nameof(page));

            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize));

            return new(filter.Value, page.Value, pageSize.Value);
        }
    }
}
