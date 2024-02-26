using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities;

public class tblCompany : IEntity
{
    public Guid Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid AddressId { get; set; }

    public virtual tblAddress Address { get; set; }

    public virtual ICollection<tblEvent> Events{ get; set; }

    public virtual ICollection<tblFriend> Friends { get; set; }
}
