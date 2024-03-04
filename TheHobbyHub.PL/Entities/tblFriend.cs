using System;
using System.Collections.Generic;
#nullable disable
namespace TheHobbyHub.PL.Entities
{   public class tblFriend : IEntity
    {
        public Guid Id { get; set; }
        //public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }

        // public virtual tblUser User { get; set; }
        public virtual ICollection<tblFriendUser> FriendUsers { get; set; }
        public virtual tblCompany Company { get; set; }
    }
}


