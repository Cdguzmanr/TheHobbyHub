using System;
using System.Collections.Generic;

namespace TheHobbyHub.PL.Entities
{
    public class tblUser : IEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Image { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Password { get; set; } = null!;
        public virtual ICollection<tblEvent> Events { get; set; }

        public virtual ICollection<tblFriend> Friends { get; set; }

        public virtual ICollection<tblUserHobby> UserHobbies { get; set; }

        public string SortField { get { return LastName; } }
    }

}

