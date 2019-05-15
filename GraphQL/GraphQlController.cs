using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLDemoAPI.GraphQL
{
    [ApiController]
    [Route("graphql")]
    public class GraphQlController : Controller
    {
        private readonly IDocumentExecuter _executor;
        private readonly ISchema _schema;

        public GraphQlController(
            IDocumentExecuter executor,
            ISchema schema)
        {
            _executor = executor;
            _schema = schema;
        }

        public async Task<IActionResult> PostAsync([FromBody] GraphQlQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var result = await _executor.ExecuteAsync(options =>
            {
                options.Schema = _schema;
                options.Query = query.Query;
                options.OperationName = query.OperationName;
                options.Inputs = inputs;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }
    }
}
