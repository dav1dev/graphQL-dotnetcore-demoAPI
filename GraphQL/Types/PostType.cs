using GraphQL.Types;
using GraphQLDemoAPI.Entities;

namespace GraphQLDemoAPI.GraphQL.Types
{
    // TODO 03: add graph types
    public class PostType : ObjectGraphType<Post>
    {
        public PostType()
        {
            Name = "Post";
            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.Body);
            Field(x => x.Comments, type: typeof(ListGraphType<CommentType>));
            Field(x => x.User, type: typeof(UserType));

            Interface<SearchInterface>();
        }
    }
}
