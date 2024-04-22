using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHobbyHub.BL.Models
{
    public class Event
    {
        public Event()
        {
            //this.Addresses = new List<Address>();
        }

        

        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid HobbyId { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
        public DateTime Date {  get; set; }

    }
}
