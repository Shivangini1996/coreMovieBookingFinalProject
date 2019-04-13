using coreUserPanel.Controllers;
using coreUserPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace UserSideTestingProject
{
    public class UserHomeTestController
    {
        HomeController controller;
        
        private ProjectTestDataContext context;
        public static DbContextOptions<ProjectTestDataContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-506; Initial Catalog = WebApiCoreTestDb; Integrated Security = true;";
        static UserHomeTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ProjectTestDataContext>().UseSqlServer(connectionString).Options;
        }

        public UserHomeTestController()
        {
            context = new ProjectTestDataContext(dbContextOptions);
            controller = new HomeController();
        }
        
            
        [Fact]
        [Trait("Home", "IndexTest")]
        public void Test1()
        {
            //Act
            IActionResult result = controller.Index();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        [Trait("Home", "MultiplexesTest")]
        public void Test2()
        {
            //Act
            IActionResult result = controller.Index();
            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        [Trait("Home", "MoviesTest")]
        public void Test3()
        {
            //Act
            IActionResult result = controller.Index();
            //Assert
            Assert.NotNull(result);

        }
    }
        }
    

