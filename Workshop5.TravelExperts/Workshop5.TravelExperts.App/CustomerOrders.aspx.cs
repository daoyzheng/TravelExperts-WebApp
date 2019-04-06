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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop5.TravelExperts.Data;
using Workshop5.TravelExperts.Domain;

namespace Workshop5.TravelExperts.App
{
    public partial class CustomerOrders : System.Web.UI.Page
    {

        public List<Package> packages = new List<Package>();
        public List<Booking> bookings = new List<Booking>();
        public List<BookingDetail> bookingDetails = new List<BookingDetail>();
        public Customer customer = new Customer();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Customer"] != null)
                customer = (Customer)Session["Customer"];
            else
            {
                Response.Redirect("~/login.aspx");
            }

            //if (((Customer)Session["Customer"]) != null)
            //    customer = (Customer)Session["Customer"];
            //else Customer = null;

            if (!IsPostBack)
            {
                packages = PackageDB.GetAllPackages();
                bookings = BookingDB.GetAllBookings();
                bookingDetails = BookingDetailDB.GetAllBookingDetails();

                // Three table LINQ join to extract relevant Fields.
                List<BookingSummary> custSummary =
                    (from b in bookings
                     join bd in bookingDetails on b.BookingId equals bd.BookingId
                     where b.CustomerId == customer.CustomerId
                     select new BookingSummary
                     {
                         //CustomerId = (int)customer.CustomerId,
                         //CustName = customer.CustFirstName + " " + customer.CustLastName,
                         //BookingNo = b.BookingNo,
                         //BookingDate = (DateTime)b.BookingDate,
                         //Description = bd.Description,
                         //TripStartDate = (DateTime)bd.TripStart,
                         //TripEndDate = (DateTime)bd.TripEnd,
                         //BBasePrice = (decimal)bd.BasePrice,
                         //BAgencyCommission = (decimal)bd.AgencyCommission

                         BookingNo = b.BookingNo,
                         BookingDate = (b.BookingDate).ToString(),
                         Description = bd.Description,
                         TripStartDate = bd.TripStart.ToString(),
                         TripEndDate = bd.TripEnd.ToString(),
                         BBasePrice = Convert.ToString(bd.BasePrice),
                         BAgencyCommission = bd.AgencyCommission.ToString(),
                         Total = (bd.BasePrice + bd.AgencyCommission).ToString()

                     }).ToList();

                gvwTravelData.DataSource = custSummary;
                gvwTravelData.DataBind();

                //int temp = 0;
                //decimal total = 0.0m;
                //for (int i = 0; i < gvwTravelData.Rows.Count; i++)
                //{
                //    decimal bp = Convert.ToDecimal(gvwTravelData.Rows[i].Cells[5].Text);
                //    decimal ac = Convert.ToDecimal(gvwTravelData.Rows[i].Cells[6].Text);
                //    gvwTravelData.Rows[i].Cells[7].Text = (bp + ac).ToString("c");

                //    //decimal up = Convert.ToDecimal(orderGridView1.Rows[i].Cells[2].Value);
                //}
            }
        }
   }
}
   