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
            this.EventAddress = new Address();
        }

        

        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid HobbyId { get; set; }
        public string Description { get; set; }
        public string ImagePath {  get; set; }
        public DateTime Date {  get; set; }

        public string EventName { get; set; }
        public string EventPostalAddress { get; set; }
        public string EventCity { get; set; }
        public string EventState { get; set; }
        public string EventZip { get; set; }
        public Address EventAddress { get; set; }
        public List<Hobby> EventHobbies { get; set; }
        public string EventUser { get; set; }
        public Company EventCompany { get; set; }
    }
}
