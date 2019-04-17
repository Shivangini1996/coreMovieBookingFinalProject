using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace coreUserPanel.Models
{
    public partial class Payments
    {
        public int PaymentId { get; set; }
       
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserDetailId { get; set; }
        
        public int BookingId { get; set; }
        public string Description { get; set; }
        public int Card { get; set; }

        public Bookings Booking { get; set; }
        
    }
}
