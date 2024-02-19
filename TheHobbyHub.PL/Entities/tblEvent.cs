using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities;

public  class tblEvent : IEntity
{
    public Guid Id { get; set; }

    public Guid AddressId { get; set; }

    public Guid UserId { get; set; }

    public Guid CompanyId { get; set; }

    public Guid HobbyId { get; set; }

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;

    public DateTime Date { get; set; }
}
