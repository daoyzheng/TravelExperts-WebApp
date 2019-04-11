/********************************************************************************
* 
* Author: Tim Leslie
* Date: April 5, 2019.
* Course: CPRG 207 Rapid OOSD Threaded Project
* Assignment: Workshop 5
* Purpose: This is a BookingSummary class definition and forms part of the CPRG 207
* Threaded Project Workshop 5.
*
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5.TravelExperts.Data
{
    public class BookingSummary
    {
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
