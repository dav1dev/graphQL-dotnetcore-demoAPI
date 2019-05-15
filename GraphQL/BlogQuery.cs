using System.Linq;
using GraphQL.Types;
using GraphQLDemoAPI.Behavior;
using GraphQLDemoAPI.Data;
using GraphQLDemoAPI.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemoAPI.GraphQL
{
    public class BlogQuery : ObjectGraphType
    {
        public BlogQuery(ApplicationDbContext dbContext)
        {
            // TODO 04: define fields
            //DefinePosts(dbContext);
            //DefineUsers(dbContext);
            //DefineComments(dbContext);

            // TODO 09: define field with filter
            //DefinePostById(dbContext);

            // TODO 10: define field using interface
            //DefineSearchInterfaceByText(dbContext);

            // TODO 11: define field using union
            //DefineSearchUnionByText(dbContext);
        }

        private void DefineComments(ApplicationDbContext dbContext) =>
            Field<ListGraphType<CommentType>>(
                "comments",
                resolve: context => dbContext.Comments
                    .Include(c => c.Post)
                    .Include(c => c.User));

        private void DefinePosts(ApplicationDbContext dbContext) =>
            Field<ListGraphType<PostType>>(
                "posts",
                resolve: context => dbContext.Posts
                    .Include(p => p.User)
                    .Include(p => p.Comments));

        private void DefineUsers(ApplicationDbContext dbContext) =>
            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => dbContext.Users
                    .Include(u => u.Posts)
                    .Include(u => u.Comments));

        private void DefinePostById(ApplicationDbContext dbContext) =>
            Field<PostType>(
                "post",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return dbContext.Posts
                        .Include(p => p.User)
                        .Include(p => p.Comments)
                        .SingleOrDefaultAsync(p => p.Id == id);
                }
            );

        private void DefineSearchInterfaceByText(ApplicationDbContext dbContext) =>
            Field<ListGraphType<SearchInterface>>(
                "search",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "text" }
                ),
                resolve: context =>
                {
                    var text = context.GetArgument<string>("text");

                    var comments = dbContext.Comments
                        .Where(c => c.Body.Contains(text))
                        .ToList();

                    var posts = dbContext.Posts
                        .Where(p => p.Body.Contains(text))
                        .ToList();

                    return comments.Cast<ISearch>().Union(posts).ToList();
                }
            );

        private void DefineSearchUnionByText(ApplicationDbContext dbContext) =>
            Field<ListGraphType<SearchUnion>>(
                "searchUnion",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "text" }
                ),
                resolve: context =>
                {
                    var text = context.GetArgument<string>("text");

                    var comments = dbContext.Comments
                        .Include(c => c.Post)
                        .Include(c => c.User)
                        .Where(c => c.Body.Contains(text))
                        .ToList();

                    var posts = dbContext.Posts
                        .Include(p => p.Comments)
                        .Include(p => p.User)
                        .Where(p => p.Title.Contains(text) || p.Body.Contains(text))
                        .ToList();

                    return comments.Cast<object>().Union(posts).ToList();
                });
    }
}
