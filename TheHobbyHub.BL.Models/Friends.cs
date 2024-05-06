using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHobbyHub.BL.Models
{
    public class Friends
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }


        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }

        [DisplayName("Company User")]
        public string CompanyName { get; set; }
    }
}
