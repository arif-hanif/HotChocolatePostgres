using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolatePostgres.Data;

namespace HotChocolatePostgres
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Project> Projects([ScopedService] AppDbContext dbContext) =>
            dbContext.Projects;
    }
}
