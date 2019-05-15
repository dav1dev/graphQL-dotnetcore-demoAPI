using GraphQL.Types;
using GraphQLDemoAPI.Entities;

namespace GraphQLDemoAPI.GraphQL.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.UserName);
            Field(x => x.Email);
            Field(x => x.Posts, type: typeof(ListGraphType<PostType>));
            Field(x => x.Comments, type: typeof(ListGraphType<CommentType>));
        }
    }
}
