using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities;

public class tblEventUser : IEntity
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }

    public virtual tblUser Users { get; set; }

    public virtual tblEvent Events { get; set; }
}
