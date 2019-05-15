using GraphQL.Types;

namespace GraphQLDemoAPI.GraphQL
{
    public class BlogSchema : Schema
    {
        public BlogSchema(BlogQuery query)
        {
            Query = query;
        }
    }
}
