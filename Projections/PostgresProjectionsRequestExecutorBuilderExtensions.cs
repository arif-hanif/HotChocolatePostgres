using System;
using HotChocolate.Data.Projections;
using HotChocolate.Data.Projections.Postgres;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolate
{
    public static class PostgresProjectionsRequestExecutorBuilderExtensions
    {
        public static IRequestExecutorBuilder AddPostgresProjections(
            this IRequestExecutorBuilder builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.ConfigureSchema(x => x.AddPostgresProjections());
        }
    }

    public static class PostgresProjectionsSchemaBuilderExtensions
    {
        public static ISchemaBuilder AddPostgresProjections(this ISchemaBuilder builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.AddConvention<IProjectionConvention>(
                new ProjectionConventionExtension(
                    x => x.AddProviderExtension(
                        new ProjectionProviderExtension(y => y.AddPostgresHandlers()))));
        }
    }
}