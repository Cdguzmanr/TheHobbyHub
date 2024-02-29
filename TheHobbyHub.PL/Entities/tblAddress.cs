using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities;

public class tblAddress : IEntity
{
    public Guid Id { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public virtual ICollection<tblEventAddress> EventAddresses { get; set; }

    public virtual ICollection<tblCompany> Companies { get; set; }

    public virtual ICollection<tblEvent> Events { get; set; }

}
