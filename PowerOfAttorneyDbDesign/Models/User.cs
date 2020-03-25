using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfAttorneyDbDesign.Models
{
    public class User
    {
	    public Guid Id { get; set; }

        public ICollection<BillingAddress> BillingAddresses { get; set; }

        public ICollection<UserCompanies> UserCompanies { get; set; }
    }
}
