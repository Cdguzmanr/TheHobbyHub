using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace TheHobbyHub.PL.Entities
{
    public class tblFriendUser
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }

         public virtual tblUser User { get; set; }
        public virtual tblFriend Friend { get; set; }
    }
}
