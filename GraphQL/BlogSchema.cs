using GraphQL.Types;

namespace GraphQLDemoAPI.GraphQL
{
    public class BlogSchema : Schema
    {
        public BlogSchema(BlogQuery query)
        {
            // TODO 05: add query to schema
            Query = query;
        }
    }
}
