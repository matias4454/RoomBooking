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
    public class RoomSelectViewComponent : ViewComponent
    {
        private RoomBookingsContext _context;

        public RoomSelectViewComponent(RoomBookingsContext ctx) 
        {
            _context = ctx;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var rooms = await _context.Room
                              .Where(r=> r.RoomId > -1)
                              .ToArrayAsync();             
            
            return View("Default", rooms);
        }
    }
}
