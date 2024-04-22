using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHobbyHub.BL.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [DisplayName("User Name")]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        public string? Email { get; set; }

        [DisplayName("Phone Number")]
        public string? PhoneNumber {  get; set; }
        public string? Image {  get; set; } = "noImage.jpg";

        [DisplayName("Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

    }
}
