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
    public class DateSelectViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BookingsViewModel model) 
        {
            ViewBag.NextDate = model.SelectedDate.AddDays(1).ToShortDateString();
            ViewBag.PrevDate = model.SelectedDate.AddDays(-1).ToShortDateString();
            ViewBag.SelectedDateStr = model.SelectedDate.ToShortDateString();
            return View(model);
        }
    }
}
