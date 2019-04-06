/********************************************************************************
* 
* Author: Tim Leslie
* Date: April 5, 2019.
* Course: CPRG 217 Rapid OOSD Threaded Project
* Assignment: Workshop 5
* Purpose: This is a Booking class definition and forms part of the CPRG 214
* Threaded Project Workshop 5.
*
*********************************************************************************/using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop5.TravelExperts.Data;
using Workshop5.TravelExperts.Domain;

namespace Workshop5.TravelExperts.App {
    public partial class CustomerOrders : System.Web.UI.Page {

        public List<Package> packages = new List<Package>();
        public List<Booking> bookings = new List<Booking>();
        public List<BookingDetail> bookingDetails = new List<BookingDetail>();
        public Customer customer = new Customer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                packages = PackageDB.GetAllPackages();
                bookings = BookingDB.GetAllBookings();
                bookingDetails = BookingDetailDB.GetAllBookingDetails();
                //customer = Session["Customer"];
                customer.CustFirstName = "Roger";

                // Three table LINQ join to extract relevant Fields.
                List<CustSummary> custSummary =
                    (from b in bookings
                     join bd in bookingDetails on b.BookingId equals bd.BookingId
                     select new CustSummary
                     {

                         CustName = customer.CustFirstName,
                         BBasePrice = (decimal)bd.BasePrice,
                         BAgencyCommission = (decimal)bd.AgencyCommission,


                     }).ToList();

                //List<CustSummary> newSummary =
                //    (from n in custSummary
                //     join p in packages on p.PackageId = n.PackageId
                //     where n.CustomerId = 104).ToList();


                gvwTravelData.DataSource = custSummary;
                gvwTravelData.DataBind();

            }
        }
    }
}