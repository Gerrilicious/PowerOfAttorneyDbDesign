using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfAttorneyDbDesign.Models
{
    public class UserCompanies
    {
	    public Guid UserId { get; set; }
	    
	    public User User { get; set; }

	    public Guid CompanyId { get; set; }
	    
	    public Company Company { get; set; }
    }
}
