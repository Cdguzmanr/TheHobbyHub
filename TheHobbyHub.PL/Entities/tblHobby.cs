using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities;

public class tblHobby : IEntity
{
    public Guid Id { get; set; }

    public string HobbyName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Image { get; set; } = null!;
}
