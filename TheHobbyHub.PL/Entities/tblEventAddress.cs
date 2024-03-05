using System;
using System.Collections.Generic;
#nullable disable
namespace TheHobbyHub.PL.Entities
{
    public class tblEventAddress : IEntity
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid AddressId { get; set; }

        public virtual tblAddress Address { get; set; }

        public virtual tblEvent Events { get; set; }
    }
}


