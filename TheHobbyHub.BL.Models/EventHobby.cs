﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHobbyHub.BL.Models
{
    public class EventHobby
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid HobbyId { get; set; }
    }
}
