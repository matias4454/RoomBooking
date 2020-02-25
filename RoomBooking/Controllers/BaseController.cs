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
    public abstract class BaseController : Controller
    {

        protected readonly RoomBookingsContext _context;

        public BaseController(RoomBookingsContext context)
        {
            _context = context;
        }

    }
}