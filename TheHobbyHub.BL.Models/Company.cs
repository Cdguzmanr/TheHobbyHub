using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHobbyHub.BL.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CompanyName { get; set; }
        public string Description {  get; set; }
        public Guid AddressId { get; set; }

        public User UserAccount { get; set; }
        public string ImagePath { get; set; }
        public string CompanyPostalAddress { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyZip {  get; set; }
        public List<Address> CompanyAddresses { get; set; }


    }
}
