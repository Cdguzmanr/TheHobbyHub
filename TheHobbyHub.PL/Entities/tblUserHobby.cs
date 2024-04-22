﻿using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities
{
    public class tblUserHobby : IEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid HobbyId { get; set; }

        public virtual tblUser User { get; set; }

        public virtual tblHobby Hobby { get; set; }

        public string SortField { get { return Hobby.Description; } }
    }
}


