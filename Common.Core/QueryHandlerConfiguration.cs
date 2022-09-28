using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.CQRS
{
    public static class QueryHandlerConfiguration
    {
        public static IServiceCollection AddQueryHandler
            <TQuery, TResult, TQueryHandler>(
            this IServiceCollection services
        ) where TQueryHandler : class, IQueryHandler<TQuery, TResult>
        {
            services
                .AddTransient<IQueryHandler<TQuery, TResult>, TQueryHandler>()
                .AddTransient<QueryHandler<TQuery, TResult>>(
                    sp => sp.GetRequiredService<IQueryHandler<TQuery, TResult>>
                    ().Handle
            );

            return services;
        }

        //public static IServiceCollection AddQueryHandler
        //    <GetAllPostsQuery, List<Post>, GetAllPostsQueryHandler>(
        //    this IServiceCollection services
        //    ) where GetAllPostsQueryHandler : class, IQueryHandler<TQuery, TResult>
        //{
        //    services
        //        .AddTransient<IQueryHandler<GetAllPostsQuery, List<Post>>,
        //        GetAllPostsQueryHandler>();

        //    services.AddTransient<QueryHandler<GetAllPostsQuery, List<Post>>>(
        //            sp => sp.GetRequiredService<IQueryHandler<GetAllPostsQuery, List<Post>>>
        //            ().Handle
        //    );

        //    return services;
        //}
    }

    public delegate ValueTask<TResult>
        QueryHandler<in TQuery, TResult>(TQuery query, CancellationToken ct);
}
