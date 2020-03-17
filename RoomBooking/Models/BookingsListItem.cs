using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoomBooking.Models;


namespace RoomBooking.Models
{
    public class BookingsListItem
    {
        public static List<BookingsListItem> CreateList(Bookings[] data) 
        {
            List<BookingsListItem> listItems = new List<BookingsListItem>();
            ;
            foreach (Bookings booking in data)
            {
                var newItem = new BookingsListItem();
                newItem.RoomName = booking.Room.RoomName;
                newItem.Date = booking.StartTime.ToShortDateString();
                newItem.BeginTime = booking.StartTime.ToShortTimeString();
                newItem.EndTime = booking.EndTime.ToShortTimeString();
                newItem.User = booking.RoomUser.Email;
                listItems.Add(newItem);
            }

            return listItems;
        }

        public int Id { get; set;}
        public string RoomName { get; set; }
        public string Date { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public string User { get; set; }

        
    }
}
