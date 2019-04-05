/********************************************************************************
* 
* Author: Tim Leslie
* Date: April 5, 2019.
* Course: CPRG 217 Rapid OOSD Threaded Project
* Assignment: Workshop 5
* Purpose: This is a Booking class definition and forms part of the CPRG 214
* Threaded Project Workshop 5.
*
*********************************************************************************/
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5.TravelExperts.Data
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingNo { get; set; }
        public double? TravelerCount { get; set; }
        public int? CustomerId { get; set; }
        public string TripTypeId { get; set; }
        public int? PackageId { get; set; }

    }
}
