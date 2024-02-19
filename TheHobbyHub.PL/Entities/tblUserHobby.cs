using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities;

public class tblUserHobby : IEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid HobbyId { get; set; }
}
