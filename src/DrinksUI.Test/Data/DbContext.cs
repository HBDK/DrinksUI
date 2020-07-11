using NUnit.Framework;
using DrinksUI.Data.Models;
using DrinksUI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace DrinksUI.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {



        }

        [Test]
        public void Test1()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            
            try
            {
                var options = new DbContextOptionsBuilder<DrinkContext>()
                    .UseSqlite(connection)
                    .Options;
                
                using (var context = new DrinkContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new DrinkContext(options))
                {

                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}