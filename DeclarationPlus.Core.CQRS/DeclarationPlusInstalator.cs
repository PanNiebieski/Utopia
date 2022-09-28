using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.CQRS
{
    public static partial class DeclarationPlusInstalator
    {
        public static IServiceCollection AddQueries (this IServiceCollection services)
        {

            //services.AddQueryHandler
            //    <GetAllPostsQuery, List<Post>, GetAllPostsQueryHandler>();


            return services;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {

            //services.AddCommandHandler
            //    <AddPostCommand, AddPostCommandHandler>();

            //services.AddCommandHandler
            //    <SendSEOCheckCommand,
            //    SendSEOCheckCommandHandler>();


            //services.AddCommandHandler
            //    <SendToGrammarCheckerCommand,
            //    SendToGrammarCheckerCommandHandler>();

            return services;
        }
    }
}
