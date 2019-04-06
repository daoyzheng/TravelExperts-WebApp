using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5.TravelExperts.Data
{
    public class BookingSummary
    {
        //public int? CustomerId { get; set; }
        //public string CustName { get; set; }
        public string BookingNo { get; set; }
        public string BookingDate { get; set; }
        public string Description { get; set; }
        public string TripStartDate { get; set; }
        public string TripEndDate { get; set; }
        public string BBasePrice { get; set; }
        public string BAgencyCommission { get; set; }
        public string Total { get; set; }
    }
}
