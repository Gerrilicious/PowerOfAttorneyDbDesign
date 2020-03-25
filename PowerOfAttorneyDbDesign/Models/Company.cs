using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfAttorneyDbDesign.Models
{
    public class Company
    {
	    public Guid Id { get; set; }

	    public string Name { get; set; }

	    public string Lei { get; set; }

	    public Guid BillingAddressId { get; set; }

	    public BillingAddress BillingAddress { get; set; }

	    public ICollection<DisclosureRequest> DisclosureRequests { get; set; }

	    public ICollection<DisclosureResponse> DisclosureResponses { get; set; }

	    public ICollection<PowerOfAttorney> PowerOfAttorneys { get; set; }

	    public ICollection<UserCompanies> UserCompanies { get; set; }
    }
}
