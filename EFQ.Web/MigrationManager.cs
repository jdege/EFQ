using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using JDege.EFQ.Web.DbContexts;

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

            var oldStartDate = invoices.OrderBy(i => i.InvoiceDate).Select(i => i.InvoiceDate).First();
            var oldEndDate = invoices.OrderByDescending(i => i.InvoiceDate).Select(i => i.InvoiceDate).First();

            var interval = oldEndDate - oldStartDate;
            var newStart = now - interval;

            foreach (var invoice in invoices)
            {
                var invoiceDate = invoice.InvoiceDate;
                var newDate = newStart + (invoiceDate - oldStartDate);

                if (newDate > now)
                    newDate = newDate.AddYears(-5);

                invoice.InvoiceDate = newDate.Date;
            }

            dbContext.SaveChanges();
        }
    }
}