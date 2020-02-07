using System;
using System.Collections.Generic;

namespace RoomBooking.Models
{
    public partial class Bookings
    {
        public int BookingId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RoomId { get; set; }
        public int RoomUserId { get; set; }

        public virtual Room Room { get; set; }
        public virtual RoomUser RoomUser { get; set; }
    }
}
