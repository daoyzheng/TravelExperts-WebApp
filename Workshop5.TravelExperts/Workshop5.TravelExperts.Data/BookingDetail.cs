/********************************************************************************
* 
* Author: Tim Leslie
* Date: April 5, 2019.
* Course: CPRG 207 Rapid OOSD Threaded Project
* Assignment: Workshop 5
* Purpose: This is a BookingDetail class definition and forms part of the CPRG 207
* Threaded Project Workshop 5.
*
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5.TravelExperts.Data
{
    public class BookingDetail
    {
        public int BookingDetailId { get; set; }
        public double? ItineraryNo { get; set; }
        public DateTime? TripStart { get; set; }
        public DateTime? TripEnd { get; set; }
        public string Description { get; set; }
        public string Destination { get; set; }
        public decimal? BasePrice { get; set; }   
        public decimal? AgencyCommission { get; set; }
        public int? BookingId { get; set; }
        public string RegionId { get; set; }
        public string ClassId { get; set; }
        public string FeeId { get; set; }
        public int? ProductSupplierId { get; set; }
    }
}
