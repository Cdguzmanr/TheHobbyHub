using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace TheHobbyHub.PL.Entities
{
    public class tblCompanyAddress
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public Guid CompanyId { get; set; }

        public virtual tblCompany Company { get; set; }

        public virtual tblAddress Address { get; set; }

    }
}
