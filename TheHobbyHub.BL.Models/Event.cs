﻿namespace TheHobbyHub.BL.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid HobbyId { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
        public DateTime Date {  get; set; }

        public List<Address> AddressList { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }
}
