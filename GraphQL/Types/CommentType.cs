using GraphQL.Types;
using GraphQLDemoAPI.Entities;

namespace GraphQLDemoAPI.GraphQL.Types
{
    public class CommentType : ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Name = "Comment";
            Field(x => x.Id);
            Field(x => x.Body);
            Field(x => x.IsAppropriate);
            Field(x => x.Post, type: typeof(PostType));
            Field(x => x.User, type: typeof(UserType));

            Interface<SearchInterface>();
        }
    }
}
