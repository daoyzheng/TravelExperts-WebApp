using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5.TravelExperts.Data
{
    public class CustSummary
    {
        public int CustomerId { get; set; }
        public string CustName { get; set; }
        public decimal BBasePrice { get; set; }
        public decimal BAgencyCommission { get; set; }
        public int PackageId { get; set; }
        public decimal PBasePrice { get; set; }
        public decimal PAgencyCommission { get; set; }

    }
}
