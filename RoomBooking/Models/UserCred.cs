using System;
using System.Collections.Generic;

namespace RoomBooking.Models
{
    public partial class UserCred
    {
        public int CredId { get; set; }
        public int UserId { get; set; }
        public string CredHash { get; set; }

        public virtual RoomUser User { get; set; }
    }
}
