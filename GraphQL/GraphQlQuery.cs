using Newtonsoft.Json.Linq;

namespace GraphQLDemoAPI.GraphQL
{
    public class GraphQlQuery
    {
        public string OperationName { get; set; }
        
        public string Query { get; set; }

        public JObject Variables { get; set; }
    }
}
