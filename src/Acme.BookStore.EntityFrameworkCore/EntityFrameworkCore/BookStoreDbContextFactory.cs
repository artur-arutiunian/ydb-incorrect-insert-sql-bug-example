using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Acme.BookStore.EntityFrameworkCore;

using global::EntityFrameworkCore.Ydb.Extensions;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class BookStoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
{
    public BookStoreDbContext CreateDbContext(string[] args)
    {
        BookStoreEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BookStoreDbContext>()
            .UseYdb(
                configuration.GetConnectionString("Default"),
                builder =>
                {
                    builder.DisableRetryOnFailure();
                });

        return new BookStoreDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Acme.BookStore.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
