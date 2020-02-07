using System;
using System.Collections.Generic;

namespace RoomBooking.Models
{
    public partial class RoomUser
    {
        public RoomUser()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
