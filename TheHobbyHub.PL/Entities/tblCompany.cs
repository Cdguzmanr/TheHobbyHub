using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities
{
    public class tblCompany : IEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string CompanyName { get; set; } = null!;
        

        public string Description { get; set; } = null!;

        public Guid AddressId { get; set; }

        public virtual tblUser User { get; set; }

        public virtual tblAddress Address { get; set; }

        public virtual ICollection<tblEvent> Events { get; set; }

        public virtual ICollection<tblFriend> Friends { get; set; }

        public string SortField { get { return CompanyName; } }
    }
}


