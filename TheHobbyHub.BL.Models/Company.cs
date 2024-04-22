﻿using System;
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
        public Address CompanyAddress { get; set; }
        public List<Address> CompanyAddresses { get; set; }

    }
}
