using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities;

public class tblEventAddress : IEntity
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Guid AddressId { get; set; }

    public virtual tblAddress Addresses { get; set; }

    public virtual tblEvent Events { get; set; }
}
