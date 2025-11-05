namespace Acme.BookStore.Ydb;

using System;
using global::EntityFrameworkCore.Ydb.Extensions;
using global::EntityFrameworkCore.Ydb.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;

public static class DbContextConfigurationContextYdbExtensions
{
    public static DbContextOptionsBuilder UseYdb(
        this AbpDbContextConfigurationContext context,
        Action<YdbDbContextOptionsBuilder>? efYdbOptionsAction = null)
    {
        if (context.ExistingConnection != null)
        {
            return context.DbContextOptions.UseYdb(
                connection: context.ExistingConnection,
                efYdbOptionsAction: efYdbOptionsAction);
        }

        return context.DbContextOptions.UseYdb(
            connectionString: context.ConnectionString,
            efYdbOptionsAction: efYdbOptionsAction);
    }
}
