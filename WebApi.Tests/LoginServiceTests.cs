using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TrackingWebApi.Tests
{
    [TestFixture]
    public class LoginServiceTests
    {
        public void GetHash_PassLoginString_ReturnsCorrectHash()
        {
            //For later time
            //use Entity Framework Effort - https://entityframework-effort.net/?z=codeplex (not supported EF Core)

            //Or in memory database of EF Core https://stormpath.com/blog/tutorial-entity-framework-core-in-memory-database-asp-net-core
            //var options = new DbContextOptionsBuilder<Context>()
            //.UseInMemoryDatabase(Object String)
            //.Options;

            //Additional Make DbContext Injection via Property and configure Dependency Injection Container
        }
    }
}
