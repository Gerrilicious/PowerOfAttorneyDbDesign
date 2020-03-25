using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfAttorneyDbDesign.Models
{
    public class PowerOfAttorney
    {
	    public Guid Id { get; set; }

	    public DateTime ExpiryDate { get; set; }

	    public DateTime Created { get; set; }

	    public Guid FinancialInstrumentId { get; set; }

	    public FinancialInstrument FinancialInstrument { get; set; }

	    public Guid CompanyId { get; set; }

	    public Company Company { get; set; }
    }
}
