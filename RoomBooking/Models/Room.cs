using System;
using System.Collections.Generic;

namespace RoomBooking.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Bookings>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int? MaxChairs { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
