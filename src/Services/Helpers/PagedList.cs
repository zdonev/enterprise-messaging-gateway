using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseMessagingGateway.Services.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevious
        {
            get { return (CurrentPage > 1); }
        }

        public bool HasNext
        {
            get { return (CurrentPage < TotalPages); }
        }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public object MetaData(string previousPageLink, string nextPageLink)
        {
            return new
            {
                totalCount = this.TotalCount,
                pageSize = this.PageSize,
                currentPage = this.CurrentPage,
                totalPages = this.TotalPages,
                previousPageLink = previousPageLink,
                nextPageLink = nextPageLink
            };
        }

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}