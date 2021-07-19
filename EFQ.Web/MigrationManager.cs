using System;
using EFQ.Web.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JDege.EFQ.Web
{
    public static class MigrationManager
    {
        // This allows us to run migrations on startup from Main().
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ChinookContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (SqlException ex)
                    {
                        throw new InvalidOperationException(
                            "Exception trying to run migrations. Did you remember to start the SqlServer Docker container?",
                        ex);
                    }
                    catch (Exception)
                    {
                        // Since we've not configured logging, we'll just throw the exception
                        throw;
                    }
                }
            }

            return host;
        }
    }
}
