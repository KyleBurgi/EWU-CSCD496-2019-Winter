﻿using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Domain.Models;
using System.Threading.Tasks;

namespace SecretSanta.Domain.Tests.Services
{
    public abstract class DatabaseServiceTests
    {
        private static ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
            {
                builder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name,
                        LogLevel.Information);
            });
            return serviceCollection.BuildServiceProvider().
                GetService<ILoggerFactory>();
        }

        private SqliteConnection SqliteConnection { get; set; }
        protected DbContextOptions<ApplicationDbContext> Options { get; private set; }

        [TestInitialize]
        public async Task OpenConnection()
        {
            SqliteConnection = new SqliteConnection("DataSource=:memory:");
            await SqliteConnection.OpenAsync();

            Options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(SqliteConnection)
                .UseLoggerFactory(GetLoggerFactory())
                .EnableSensitiveDataLogging()
                .Options;

            using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                await context.Database.EnsureCreatedAsync();
            }
        }

        [TestCleanup]
        public void CloseConnection()
        {
            SqliteConnection.Close();
        }
    }
}