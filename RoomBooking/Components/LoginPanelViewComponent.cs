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
    public class LoginPanelViewComponent : ViewComponent
    {
        private RoomBookingsContext _context;

        public LoginPanelViewComponent(RoomBookingsContext context) 
        {
            _context = context;
        }
        public IViewComponentResult Invoke() 
        {          
            return View("Default");
        }
        /*
        public async Task<IViewComponentResult> InvokeAsync(string login, string password) 
        {
            
        }*/

    }
}
