using System.Collections.Generic;
using DrinksUI.Data;
using DrinksUI.Data.Services;
using DrinksUI.Dtos.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace DrinksUI.Test.service
{
    [TestFixture]
    public class MachineSlotServiceTest
    {
        private MachineSlotService _sut;
        private SqliteConnection _connection;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<DrinkContext>()
                .UseSqlite(_connection)
                .Options;

            var context = new DrinkContext(options);

            _sut = new MachineSlotService(context);

            var task = context.AddMockData();
            task.Wait();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _connection.Close();
        }

        [Test]
        public void GetSlots()
        {
            var task = _sut.GetSlots();
            IEnumerable<IMachineSlot> slots = task.Result;

            Assert.That(slots, Is.Not.Null);
        }
    }
}