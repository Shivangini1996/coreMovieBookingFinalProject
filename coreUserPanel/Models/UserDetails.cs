using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace coreUserPanel.Models
{
    public partial class UserDetails
    {
        public UserDetails()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int UserDetailId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int ContactNo { get; set; }
        [Required]
        public string UserName { get; set; }

        public Reviews Reviews { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
    }
}
