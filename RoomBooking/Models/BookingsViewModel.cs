using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBooking.Models
{
    public class BookingsViewModel
    {
        public int SelectedRoomId { get; set; }
        public DateTime SelectedDate { get; set; }

       // public List<BookingsListItem> Items { get; set; }
    }
}
