using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfAttorneyDbDesign.Models
{
    public class DisclosureRequest
    {
	    public Guid Id { get; set; }

	    public Guid CompanyId { get; set; }

	    public Company Company { get; set; }

	    public ICollection<DisclosureResponse> DisclosureResponses { get; set; }

	    public Guid FinancialInstrumentId { get; set; }

	    public FinancialInstrument FinancialInstrument { get; set; }
    }
}
