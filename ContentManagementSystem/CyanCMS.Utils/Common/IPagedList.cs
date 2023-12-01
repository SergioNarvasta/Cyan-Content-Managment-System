using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyan.Utils.Common
{
    public interface IPagedList<out T> : IPagedList, IEnumerable<T>, IEnumerable
    {
        T this[int index] { get; }

        int Count { get; }

        IPagedList GetMetaData();
    }

    public interface IPagedList
    {
        int PageCount { get; }

        int TotalItemCount { get; }

        int PageNumber { get; }

        int PageSize { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }

        bool IsFirstPage { get; }

        bool IsLastPage { get; }

        int FirstItemOnPage { get; }

        int LastItemOnPage { get; }

        string ResponseContinuation { get; set; }
    }
}
