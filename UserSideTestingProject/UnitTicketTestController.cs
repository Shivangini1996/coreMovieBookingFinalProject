using coreUserPanel.Controllers;
using coreUserPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace UserSideTestingProject
{
    public class UserTicketController
    {
        TicketController controller;

        private ProjectTestDataContext context;
        public static DbContextOptions<ProjectTestDataContext> dbContextOptions { get; set; }

        public static string connectionString = "Data Source=TRD-506; Initial Catalog = WebApiCoreTestDb; Integrated Security = true;";
        static UserTicketController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ProjectTestDataContext>().UseSqlServer(connectionString).Options;
        }
        public UserTicketController()
        {
            context = new ProjectTestDataContext(dbContextOptions);
            controller = new TicketController();
        }
        [Fact]
        [Trait("Ticket", "DirectLogin")]
        public void DirectLogin()
        {
            //Act
            IActionResult result = controller.DirectLogin();
            //Assert
            Assert.NotNull(result);



        }
        [Fact]
        public void Task_Ticket_Return_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new TicketController();

                var UserName = "bgunwani";
                var Password = "1";
                var data = controller.DirectLogin(UserName, Password);
                Assert.IsType<RedirectToActionResult>(data);
            });
        }
        [Fact]
        public void Task_Ticket_Login_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new TicketController();

                var UserName = "bgunwani";
                var Password = "1";
                var data = controller.Login(UserName, Password);
                Assert.IsType<RedirectToActionResult>(data);
            });

        }
        [Fact]
        public void Task_Ticket_Logout_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new TicketController();

                var data = controller.Logout();
                Assert.IsType<RedirectToActionResult>(data);
            });
        }
        [Fact]
        public void Task_Ticket_Checkout_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new TicketController();


                var data = controller.Checkout();
                Assert.IsType<RedirectToActionResult>(data);
            });

        }
        [Fact]
        public void Task_Ticket_DirectRegister_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new TicketController();
                var item = new UserDetails();
                item.Email = "shivanginisaxena20@gmail.com";
                item.Password = "12";
                item.ContactNo = 1234;
                item.UserName = "srishti";

                var data = controller.DirectRegister(item);
                Assert.IsType<RedirectToActionResult>(data);
            });

        }
        [Fact]
        public void Task_Ticket_NewRegister_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new TicketController();
                var item = new UserDetails();
                item.Email = "shivanginisaxena20@gmail.com";
                item.Password = "12";
                item.ContactNo = 1234;
                item.UserName = "bhavya";

                var data = controller.NewRegister(item);
                Assert.IsType<RedirectToActionResult>(data);
            });

        }
        [Fact]
        [Trait("Ticket", "Invoice")]
        public void Invoice()
        {
            Assert.Throws<NullReferenceException>(() =>
            {

                //Act
                IActionResult result = controller.NewInvoice();
                //Assert
                Assert.NotNull(result);
            });


        }
        [Fact]
        public void Task_Ticket_EditProfile_OkResult()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new TicketController();
                var item = new UserDetails();
                item.UserDetailId = 62;
                item.Email = "srishti@gmail.com";


                var data = controller.EditProfile(item);
                Assert.IsType<RedirectToActionResult>(data);
            });

        }
        [Fact]
        [Trait("Ticket", "ViewProfile")]
        public void ViewProfile()
        {
            Assert.Throws<NullReferenceException>(() =>
            {

                //Act
                IActionResult result = controller.ViewProfile();
                //Assert
                Assert.NotNull(result);
            });


        }
        [Fact]
        [Trait("Ticket", "BookingHistory")]
        public void BookingHistory()
        {
            Assert.Throws<NullReferenceException>(() =>
            {

                //Act
                IActionResult result = controller.BookingHistory();
                //Assert
                Assert.NotNull(result);
            });


        }
        [Fact]
        [Trait("Ticket", "ChangePassword")]
        public void ChangePassword()
        {

            var item = new UserDetails();
            item.UserDetailId = 62;
            item.Password = "45";
            //Act
            IActionResult result = controller.ChangePassword();
            //Assert
            Assert.NotNull(result);



        }
        



    } }

