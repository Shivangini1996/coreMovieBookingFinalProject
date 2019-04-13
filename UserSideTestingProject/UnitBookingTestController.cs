using coreUserPanel.Controllers;
using coreUserPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UserSideTestingProject
{
    public class UserBookingTestController
    {
        BookingController controller;

        private ProjectTestDataContext context;
        public static DbContextOptions<ProjectTestDataContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-506; Initial Catalog = WebApiCoreTestDb; Integrated Security = true;";
        static UserBookingTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ProjectTestDataContext>().UseSqlServer(connectionString).Options;
        }

        public UserBookingTestController()
        {
            context = new ProjectTestDataContext(dbContextOptions);
            controller = new BookingController();
        }
        //[Fact]
        //public void Task_Ticket_Book_OkResult()
        //{
        //    Assert.Throws<NullReferenceException>(() =>
        //    {
        //        var controller = new BookingController();


        //        var data = controller.Book();
        //        Assert.IsType<RedirectToActionResult>(data);
        //    });

        }    }
    


