using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities;

public class tblEventHobby : IEntity
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Guid HobbyId { get; set; }

    public virtual tblHobby Hobbies { get; set; }

    public virtual tblEvent Events { get; set; }
}
