using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PingPongWebApplication.Models;
using PingPongWebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private DataContext _Context;

        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "PingPongDB").Options;

            var context = new DataContext(builder);
            var players = Enumerable.Range(1, 10)
                .Select(i => new Players { Id = i, FirstName = "Chandni", LastName = "Shah", Age = 23, SkillLevel = "Advanced", Email = "cshah9925@gmail.com" });
            context.Players.AddRange(players);
            int changed = context.SaveChanges();
            _Context = context;
        }

        [Test]
        public void Test_GetPlayerById()
        {
            string expectedFirstName = "Chandni";
            var controller = new HomeController(_Context);
            Players result = controller.Get(1);
            Assert.AreEqual(expectedFirstName, result.FirstName);
        }

        [Test]
        public void Test_GetAllPlayers()
        {
            var controller = new HomeController(_Context);
            IEnumerable<Players> result = controller.Index();
            Assert.AreEqual(_Context.Players.ToList(), result);
        }
    }
}