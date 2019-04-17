using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreUserPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stripe;

namespace coreUserPanel.Controllers
{
    public class PaymentController : Controller
    {
        ProjectTestDataContext context = new ProjectTestDataContext();

        public IActionResult Charge(string stripeEmail, string stripeToken)
            {
                var customers = new CustomerService();
                var charges = new ChargeService();

                var customer = customers.Create(new CustomerCreateOptions
                {
                    Email = stripeEmail,
                    SourceToken = stripeToken
                });

                var charge = charges.Create(new ChargeCreateOptions
                {
                    Amount = 500,
                    Description = "Sample Charge",
                    Currency = "usd",
                    CustomerId = customer.Id
                });
            //Payments payment = new Payments()
            //{
            //    = charge.PaymentMethodId,
            //    Amount = 500,
            //    CreatedDate = System.DateTime.Now,
            //    Description = "Payment Initiated..",
            //    Card = Convert.ToInt32(charge.PaymentMethodDetails.Card.Last4)
            //};
            //context.Add<Payments>(payment);
            //context.Payments.Add(payment);
            //context.SaveChanges();
            //var customerService = new CustomerService();
            //ViewBag.details = charge.PaymentMethodDetails.Card.Last4;

            return View();
            }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        
        public IActionResult Payment()
        {
            return View();
            
        }
            
        }

    }
    
