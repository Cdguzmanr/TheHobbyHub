using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities
{
    public class tblFriend : IEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid CompanyId { get; set; }

        public virtual tblUser User { get; set; }

        public virtual tblCompany Company { get; set; }
    }

}

