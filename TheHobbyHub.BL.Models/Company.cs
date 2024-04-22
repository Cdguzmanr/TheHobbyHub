using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHobbyHub.BL.Models
{
    public class Company : User
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Image {  get; set; }
        public Guid AddressId { get; set; }

        public User UserAccount { get; set; }

    }
}
