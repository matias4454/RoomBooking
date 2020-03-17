using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomBooking.Models;
using RoomBooking.Data;

namespace RoomBooking.Components
{
    public class BookingsListViewComponent : ViewComponent
    {
        private RoomBookingsContext _context;

        public BookingsListViewComponent(RoomBookingsContext ctx) 
        {
            _context = ctx;
        }
        public async Task<IViewComponentResult> InvokeAsync(BookingsViewModel model) 
        {
            if (model.SelectedDate == null) 
            {
                model.SelectedDate = DateTime.Now;
            }
            
            Bookings[] bookings = await _context.Bookings
                              .Include(b => b.RoomUser)
                              .Include(b => b.Room)
                              .Where(b => b.StartTime.Date.Year.Equals(model.SelectedDate.Year) 
                              && b.StartTime.Date.Month.Equals(model.SelectedDate.Month)
                              && b.StartTime.Date.Day.Equals(model.SelectedDate.Day))// && b.StartTime.Date == model.SelectedDate)                              
                              .Where(b => b.Room.RoomId == model.SelectedRoomId)
                              .ToArrayAsync();
            ;
            List<BookingsListItem> items = BookingsListItem.CreateList(bookings);

            return View("Default", items.ToArray());
        }
    }
}
