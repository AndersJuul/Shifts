//using System;
//using System.Data.SqlClient;
//using System.Diagnostics;
//using DbUp;
//using NUnit.Framework;
//using Shifts.Migrations;

//namespace Shifts.Tests.IntegrationTests
//{
//    [TestFixture]
//    public abstract class IntegrationTestBase
//    {
//        [SetUp]
//        public void Setup()
//        {
//            DbName = "Database=Shifts.Drivers." + DateTime.Now.ToString("yyyy-MM-dd.HH.mm.ss");

//            Debug.WriteLine("Creating test db: " + DbName);

//            ConnectionString = "Server=(local)\\SqlExpress; " + DbName + "; Trusted_connection=true";

//            EnsureDatabase.For.SqlDatabase(ConnectionString);

//            var upgrader =
//                DeployChanges.To
//                    .SqlDatabase(ConnectionString)
//                    .WithScriptsEmbeddedInAssembly(typeof(Program).Assembly)
//                    .LogToConsole()
//                    .Build();

//            var result = upgrader.PerformUpgrade();
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            using (var con = new SqlConnection(ConnectionString))
//            {
//                con.Open();
//                con.ChangeDatabase("master");
//                new SqlCommand(@"ALTER DATABASE [" + DbName + @"] SET SINGLE_USER WITH ROLLBACK IMMEDIATE",
//                    con)
//                    .ExecuteNonQuery();
//                new SqlCommand(@"DROP DATABASE [" + DbName + "]",
//                    con)
//                    .ExecuteNonQuery();
//            }
//            Debug.WriteLine("Creating test db: " + DbName);
//        }

//        protected string ConnectionString;
//        protected string DbName;
//    }
//}