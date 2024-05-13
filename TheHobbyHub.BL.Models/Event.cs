using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Image")]
        public string ImagePath {  get; set; }
        public DateTime Date {  get; set; }
        [DisplayName("Event Name")]
        public string EventName { get; set; }
        [DisplayName("Street Address")]
        public string EventPostalAddress { get; set; }
        [DisplayName("City")]
        public string EventCity { get; set; }
        [DisplayName("State")]
        public string EventState { get; set; }
        [DisplayName("Zip")]
        public string EventZip { get; set; }
        public Address EventAddress { get; set; }
        
        public List<Hobby> EventHobbies { get; set; }
        [DisplayName("Hobbies")]
        public string EventHobby { get; set; }
        [DisplayName("Event Host")]
        public string EventUser { get; set; }
        public Company EventCompany { get; set; }
    }
}
