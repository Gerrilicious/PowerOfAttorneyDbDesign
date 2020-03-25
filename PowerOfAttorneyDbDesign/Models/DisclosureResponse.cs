using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfAttorneyDbDesign.Models
{
    public class DisclosureResponse
    {
	    public Guid Id { get; set; }

	    public Guid DisclosureRequestId { get; set; }

	    public DisclosureRequest DisclosureRequest { get; set; }

	    public Guid CompanyId { get; set; }

	    public Company Company { get; set; }
    }
}
