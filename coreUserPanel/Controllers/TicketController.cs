using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreUserPanel.Helpers;
using coreUserPanel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreUserPanel.Controllers
{
   
    public class TicketController : Controller
    {

        public int discount = 100;

        public string audiName;
        ProjectTestDataContext context = new ProjectTestDataContext();
        
        [HttpGet]

        public IActionResult Login()
        {
            var user = HttpContext.Session.GetString("uid");

            if (user != null)
            {
                
                int custId = int.Parse(HttpContext.Session.GetString("uid"));
                return RedirectToAction("Checkout" , "Ticket", new { @id = custId });
            }
            else
            {

                return View("Login");
            }
            
        }

        [HttpGet]
        public IActionResult DirectLogin()
        {
            return View("DirectLogin");
        }

        [HttpPost]
        public IActionResult DirectLogin(string username, string password)
        {
            var user = context.UserDetails.Where(x => x.UserName == username && x.Password == password).SingleOrDefault();
            HttpContext.Session.SetString("uid", (user.UserDetailId).ToString());
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = context.UserDetails.Where(x => x.UserName == username && x.Password == password).SingleOrDefault();
            if (user == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return RedirectToAction("Login", "Ticket");
            }
            else
            {
                HttpContext.Session.SetString("uid", (user.UserDetailId).ToString());
                return RedirectToAction("Checkout", "Ticket");
                
            }
        }
        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uid");
            return RedirectToAction("Index","Home");
        }
        [Route("ChangePassword")]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Route("ChangePassword")]
        [HttpPost]
        public IActionResult ChangePassword(string oldpassword, string newpassword, string newpassword1)
        {
           int id = int.Parse( HttpContext.Session.GetString("uid"));
            UserDetails c = context.UserDetails.Where(x => x.UserDetailId == id).SingleOrDefault();
            if (oldpassword == c.Password && newpassword == newpassword1)
            {
                UserDetails cus = context.UserDetails.Where(x => x.UserName == c.UserName).SingleOrDefault();
                cus.Password = newpassword;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "bookmovie", cus);
                context.SaveChanges();
            }
            else
            {
                ViewBag.Error = "  Invalid Credentials";
                return View("Password");
            }
            return RedirectToAction("Login", "Ticket");
        }

        

        [HttpGet]
        public ActionResult DirectRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DirectRegister(UserDetails userDetails)
        {
            if(ModelState.IsValid)
            {
                context.UserDetails.Add(userDetails);
                context.SaveChanges();
                HttpContext.Session.SetString("uid", (userDetails.UserDetailId).ToString());
                return RedirectToAction("Index", "Home");
            }
            return View();
            
        }
        
        public ActionResult NewRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewRegister(UserDetails userDetails)
        {
            if(ModelState.IsValid)
            {
                context.UserDetails.Add(userDetails);
                context.SaveChanges();
                HttpContext.Session.SetString("uid", (userDetails.UserDetailId).ToString());
                return RedirectToAction("Checkout", "Ticket");
            }
            return View();
        }

        public void checkAudi(string showTiming)
        {
            if(showTiming == "12 Noon")
            {
                audiName = "Audi 1";
            }
            else if (showTiming == "3 PM")
            {
                audiName = "Audi 2";
            }
            else if (showTiming == "6 PM")
            {
                audiName = "Audi 3";
            }
        }

        [Route("Checkout")]
        public IActionResult Checkout()
        {
            var id = Convert.ToInt32(HttpContext.Session.GetString("uid"));
            //var id = int.Parse(TempData["uid"].ToString());
            var userDetails = context.UserDetails.Where(x => x.UserDetailId == id).SingleOrDefault();
            //UserDetails userDetails = context.UserDetails.Where(x => x.UserDetailId == id).SingleOrDefault();
            //ViewBag.UserDetails = userDetails;

            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");

            if (bookmovie == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.bookmovie = bookmovie;
                ViewBag.total = bookmovie.Sum(item => item.Movies.MoviePrice * item.Quantity);
                //ViewBag.totalitem = bookmovie.Count();
                TempData["total"] = ViewBag.total;
                TempData["uid"] = id;
                return View(userDetails);
            }
           
        }
        [Route("Checkout")]
        [HttpPost]

        public IActionResult Checkout(UserDetails userDetails)
        {
            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");

            var showTiming = Request.Form["showTiming"].ToString();
            var amount = (TempData["total"]);
            var uid = (TempData["uid"]).ToString();
            checkAudi(showTiming);

            Bookings booking = new Bookings()
            {
                BookingAmount = Convert.ToInt32(amount),
                BookingDate = DateTime.Now,
                ShowTiming = showTiming,
                AudiName = audiName,
                UserDetailId = Convert.ToInt32(uid)
            };
            context.Bookings.Add(booking);
            context.SaveChanges();

            List<BookingDetails> BookingDetail = new List<BookingDetails>();
            for (int i = 0; i < bookmovie.Count; i++)
            {
                BookingDetails bookingDetail = new BookingDetails()
                {
                    BookingId = booking.BookingId,
                    MovieId = bookmovie[i].Movies.MovieId,
                    QtySeats = bookmovie[i].Quantity
                };
                context.BookingDetails.Add(bookingDetail);
            }
            BookingDetail.ForEach(n => context.BookingDetails.Add(n));
            context.SaveChanges();

            TempData.Keep("uid");
            TempData["bookingId"] = booking.BookingId;
            return RedirectToAction("NewInvoice", "Ticket");
        }


       

        public IActionResult NewInvoice()
        {
            
            int userId = Convert.ToInt32(TempData["uid"]);
            int bookingId = Convert.ToInt32(TempData["bookingId"]);
        

            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            UserDetails user = context.UserDetails.Where(u => u.UserDetailId == userId).SingleOrDefault();
            Bookings book = context.Bookings.Where(b => b.BookingId == bookingId).SingleOrDefault();

            //Bookings booking = context.Bookings.Where()
            //Bookings booking = context.Bookings.Where(b => b.UserDetailId == userId).SingleOrDefault();
         
            ViewBag.bookmovie = bookmovie;
            ViewBag.Total = bookmovie.Sum(item => item.Movies.MoviePrice * item.Quantity);
            ViewBag.user = user;
            ViewBag.book = book;
            ViewBag.discount = discount;
            ViewBag.subtotal = ViewBag.Total - discount;
            return View();


        }


        public IActionResult ViewProfile()
        {
            int id = int.Parse(HttpContext.Session.GetString("uid"));
            UserDetails c = context.UserDetails.Where(x => x.UserDetailId == id).SingleOrDefault();
            return View(c);
        }

        public IActionResult BookingHistory()
        {
            int id = int.Parse(HttpContext.Session.GetString("uid"));
            Bookings c = context.Bookings.Where(x => x.UserDetailId == id).SingleOrDefault();
            return View(c);


        }
        

        
        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditProfile( UserDetails m1)
        {
            int id = int.Parse(HttpContext.Session.GetString("uid"));
            UserDetails user = context.UserDetails.Where(x => x.UserDetailId == id).SingleOrDefault();
            user.UserName = m1.UserName;
            user.Email = m1.Email;
            user.ContactNo = m1.ContactNo;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
    
}



