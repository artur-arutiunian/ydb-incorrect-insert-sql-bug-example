namespace Acme.BookStore.Ydb;

using System;
using global::EntityFrameworkCore.Ydb.Infrastructure;
using Volo.Abp.EntityFrameworkCore;

public static class DbContextOptionsYdbExtensions
{
    public static void UseYdb(
        this AbpDbContextOptions options,
        Action<YdbDbContextOptionsBuilder>? efYdbOptionsAction = null)
    {
        options.Configure(context =>
        {
            context.UseYdb(efYdbOptionsAction);
        });
    }

    public static void UseYdb<TDbContext>(
        this AbpDbContextOptions options,
        Action<YdbDbContextOptionsBuilder>? efYdbOptionsAction = null)
        where TDbContext : AbpDbContext<TDbContext>
    {
        options.Configure<TDbContext>(context =>
        {
            context.UseYdb(efYdbOptionsAction);
        });
    }
}
