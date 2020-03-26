using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfAttorneyDbDesign.Models
{
    public class FinancialInstrument
    {
	    public Guid Id { get; set; }

	    public ICollection<PowerOfAttorney> PowerOfAttorneys { get; set; }

	    public ICollection<DisclosureRequest> DisclosureRequests { get; set; }

	    public Guid CompanyId { get; set; }

	    public Company Company { get; set; }
    }
}
