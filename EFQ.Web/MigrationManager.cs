using System;
using System.Linq;
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
                var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ChinookContext>>();

                using (var appContext = contextFactory.CreateDbContext())
                {
                    try
                    {
                        appContext.Database.Migrate();

                        AdjustDates(appContext);
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

        // We want to adjust the invoice dates so that they range from now to five years ago,
        // instead of from 2009 to 2013.
        private static void AdjustDates(ChinookContext dbContext)
        {
            var invoices = dbContext.Invoices.ToList();

            var now = DateTime.Now;
            var nowYearMinusFour = now.Year - 4;

            foreach (var invoice in invoices)
            {
                var invoiceDate = invoice.InvoiceDate;
                var yearMod5 = invoiceDate.Year % 5;
                var newYear = nowYearMinusFour + yearMod5;
                var newDate = new DateTime(newYear, invoiceDate.Month, invoiceDate.Day);

                if (newDate > now)
                {
                    newDate = newDate.AddYears(-5);
                }

                invoice.InvoiceDate = newDate;
            }

            dbContext.SaveChanges();
        }
    }
}
