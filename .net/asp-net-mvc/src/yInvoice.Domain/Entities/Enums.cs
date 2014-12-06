using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yInvoice.Domain.Entities
{
    public enum UserRole
    {
        Client,
        StaffMember,
        Admin
    }
    public enum Statuses
    {
        New,
        Rejected,
        Viewed,
        Payed,        
    }
}
