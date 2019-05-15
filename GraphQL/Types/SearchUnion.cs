using GraphQL.Types;

namespace GraphQLDemoAPI.GraphQL.Types
{
    public class SearchUnion : UnionGraphType
    {
        public SearchUnion()
        {
            Type<CommentType>();
            Type<PostType>();
        }
    }
}
