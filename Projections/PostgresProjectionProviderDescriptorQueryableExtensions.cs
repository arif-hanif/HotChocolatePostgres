namespace HotChocolate.Data.Projections.Postgres
{
    public static class PostgresProjectionProviderDescriptorQueryableExtensions
    {
        public static IProjectionProviderDescriptor AddPostgresHandlers(
            this IProjectionProviderDescriptor descriptor) =>
            descriptor.RegisterFieldHandler<QueryablePostgresProjectionJsonHandler>();
    }
}