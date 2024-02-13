using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHobbyHub.BL.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PostalAddress {  get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip {  get; set; }

    }
}
