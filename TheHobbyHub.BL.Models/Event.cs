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
        public string Image {  get; set; }
        public DateTime Date {  get; set; }

        public string EventName { get; set; }
        public Address EventAddress { get; set; }
        public List<Hobby> EventHobbies { get; set; }
        public User EventUser { get; set; }
        public Company EventCompany { get; set; }
    }
}
