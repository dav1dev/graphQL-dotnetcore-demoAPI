using GraphQLDemoAPI.Entities;

namespace GraphQLDemoAPI.Behavior
{
    public interface ISearch
    {
        int Id { get; }
        
        string Body { get; }

        User User { get; }
    }
}
