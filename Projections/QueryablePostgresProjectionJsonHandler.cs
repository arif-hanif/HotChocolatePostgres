using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HotChocolate.Data.Projections.Expressions.Handlers;
using HotChocolate.Execution.Processing;

namespace HotChocolate.Data.Projections.Postgres
{
    public class QueryablePostgresProjectionJsonHandler
        : QueryableProjectionScalarHandler
    {
        public override bool CanHandle(ISelection selection)
        {
            if (selection.Field.Member is not null)
            {
                var attributes = (ColumnAttribute[]) selection.Field.Member
                    .GetCustomAttributes(typeof(ColumnAttribute), false);
                return attributes.Any(x => x.TypeName == "jsonb");
            }

            return false;
        }
    }
}