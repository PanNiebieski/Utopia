using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.CQRS
{
    //public interface IQueryHandler<in T, TResult>
    //{
    //    TResult Handle(T query, CancellationToken ct);
    //}

    //public interface IQueryHandler<in T, TResult>
    //{
    //    Task<TResult> Handle(T query, CancellationToken ct);
    //}

    public interface IQueryHandler<in TQuery, TResult>
    {
        ValueTask<TResult> Handle(TQuery query, CancellationToken ct);
    }
}
