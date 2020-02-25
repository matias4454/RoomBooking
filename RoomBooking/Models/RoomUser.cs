using System;
using System.Collections.Generic;

namespace RoomBooking.Models
{
    public partial class RoomUser
    {
        public RoomUser()
        {
            Bookings = new HashSet<Bookings>();
            UserCred = new HashSet<UserCred>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
        public virtual ICollection<UserCred> UserCred { get; set; }
    }
}
