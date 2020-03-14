using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoomBooking.Data;
using RoomBooking.Models;

namespace RoomBooking.Controllers
{
    public class RoomScheduleController : BaseController// Controller
    {
        public RoomScheduleController(RoomBookingsContext context) : base(context) 
        { }

        public async Task<IActionResult> Index()
        {
            var collection = await _context.Bookings
                .Include(b => b.Room)
                .Include(b => b.RoomUser)
                .ToListAsync();

            List<BookingsListItem> items = BookingsListItem.CreateList(collection.ToArray());
          
            return View(items);
        }
    }
}