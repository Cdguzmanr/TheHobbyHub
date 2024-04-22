﻿using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities
{
    public class tblAddress : IEntity
    {
        public Guid Id { get; set; }

        public string PostalAddress { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public string Zip { get; set; } = null!;

        public virtual ICollection<tblCompany> Companies { get; set; }

        public virtual ICollection<tblEvent> Events { get; set; }
        public string SortField { get { return City; } }


    }

}

