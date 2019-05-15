using GraphQL.Types;
using GraphQLDemoAPI.Behavior;

namespace GraphQLDemoAPI.GraphQL.Types
{
    public class SearchInterface : InterfaceGraphType<ISearch>
    {
        public SearchInterface()
        {
            Name = "Search";
            Field(x => x.Id);
            Field(x => x.Body);
            Field(x => x.User, type: typeof(UserType));
        }
    }
}
