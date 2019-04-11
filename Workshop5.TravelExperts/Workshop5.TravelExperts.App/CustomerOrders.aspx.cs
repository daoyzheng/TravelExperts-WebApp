/********************************************************************************
* 
* Author: Tim Leslie
* Date: April 5, 2019.
* Course: CPRG 207 Rapid OOSD Threaded Project
* Assignment: Workshop 5
* Purpose: This is a collection of methods for the CustomerOrders page and
* forms part of the CPRG 207 Threaded Project Workshop 5. The form_load
* method handles the majority of GridView controls which display the 
* Travel Product and Package orders.
*
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
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
        // instantiate Package, Booking and BookingDetail Lists from the TravelExperts database.
        public List<Package> packages = new List<Package>();
        public List<Booking> bookings = new List<Booking>();
        public List<BookingDetail> bookingDetails = new List<BookingDetail>();
        public Customer cust = new Customer();

        // boolean variables to be used as flags for Travel Order display
        public bool bookS = false;
        public bool packS = false;

        public string custName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // if Session Customer variable is not null then assign it
            // to a Customer object and set up a Razor variable for customer name.
            if (Session["Customer"] != null)
            {
                cust = (Customer)Session["Customer"];
                custName = $"{cust.CustFirstName} {cust.CustLastName}";
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }

            if (!IsPostBack) // on first time page load
            {
                // populate Package, Booking and BookingDetail Lists from database
                packages = PackageDB.GetAllPackages();
                bookings = BookingDB.GetAllBookings();
                bookingDetails = BookingDetailDB.GetAllBookingDetails();

                // Two table LINQ join to extract relevant Fields for display in the
                // Customer Orders table. This selection is customizable depending on
                // what the clients would like to have displayed in the Customer Orders
                // table. Fields are stored in BookingSummary objects.
                List<BookingSummary> bookSummary =
                    (from b in bookings
                     join bd in bookingDetails on b.BookingId equals bd.BookingId
                     where b.CustomerId == cust.CustomerId
                     select new BookingSummary // assign the Linq results to a List of BookingSummary objects.
                     {
                         BookingNo = b.BookingNo,
                         BookingDate = ((DateTime)(b.BookingDate)).ToString("d"),
                         Description = bd.Description,
                         TripStartDate = ((DateTime)bd.TripStart).ToString("d"),
                         TripEndDate   = ((DateTime)bd.TripEnd).ToString("d"),
                         BBasePrice = ((decimal)(bd.BasePrice)).ToString("c"),
                         BAgencyCommission = ((decimal)(bd.AgencyCommission)).ToString("c"),
                         Total = ((decimal)(bd.BasePrice + bd.AgencyCommission)).ToString("c")

                     }).ToList();

                bool isEmpty = !bookSummary.Any();
                if (!isEmpty) // if there are Travel Products, execute the following block
                {
                    bookS = true;

                    // iterate through the BookingSummary List to calculate column
                    // totals for Price, Commission and Total
                    decimal totBase1 = 0.0m;
                    decimal totComm1 = 0.0m;
                    decimal totTotl1 = 0.0m;
                    foreach (BookingSummary book in bookSummary) // iterate throught the list to calculate totals
                    {
                        string temp = "";
                        temp = (book.BBasePrice).Remove(0, 1); // remove dollar sign prior to parsing text to decimal
                        totBase1 += decimal.Parse(temp);        // calculate running total for Base Price
                        temp = (book.BAgencyCommission).Remove(0, 1);
                        totComm1 += decimal.Parse(temp);
                        temp = (book.Total).Remove(0, 1);
                        totTotl1 += decimal.Parse(temp);
                    }
                    // sort the BookingSummary List by descending date
                    List<BookingSummary> newList = bookSummary.OrderByDescending(b => b.BookingDate).ToList();

                    // Build a dummy BookingSummary Record for the last Totals line in the GridView
                    BookingSummary book1 = new BookingSummary();
                    book1.BookingNo = "";
                    book1.BookingDate = "";
                    book1.Description = "";
                    book1.TripStartDate = "";
                    book1.TripEndDate = "Totals";
                    book1.BBasePrice = totBase1.ToString("c");
                    book1.BAgencyCommission = totComm1.ToString("c");
                    book1.Total = totTotl1.ToString("c");

                    newList.Add(book1); // add the Totals line to the List

                    gvwTravelData.DataSource = newList; // assign list as data source
                    gvwTravelData.DataBind(); // bind the GridView data

                    int rowCount = gvwTravelData.Rows.Count;
                    // format the Total row
                    gvwTravelData.Rows[rowCount - 1].Cells[4].Font.Bold = true;
                    gvwTravelData.Rows[rowCount - 1].Cells[5].Font.Bold = true;
                    gvwTravelData.Rows[rowCount - 1].Cells[6].Font.Bold = true;
                    gvwTravelData.Rows[rowCount - 1].Cells[7].Font.Bold = true;

                    gvwTravelData.HeaderRow.HorizontalAlign = HorizontalAlign.Center;
                }

                // Use a LINQ query to join the Bookings and Packages tables and poulate
                // a list of BookingSummary objects for Travel Packages.
                List<BookingSummary> packSummary =
                    (from b in bookings
                     join p in packages on b.PackageId equals p.PackageId
                     where b.CustomerId == cust.CustomerId
                     select new BookingSummary
                     {
                         BookingNo = b.BookingNo.ToString(),
                         BookingDate = ((DateTime)(b.BookingDate)).ToString("d"),
                         Description = p.PkgDesc,
                         TripStartDate = ((DateTime)p.PkgStartDate).ToString("d"),
                         TripEndDate = ((DateTime)p.PkgEndDate).ToString("d"),
                         BBasePrice = ((decimal)(p.PkgBasePrice)).ToString("c"),
                         BAgencyCommission = ((decimal)(p.PkgAgencyCommission)).ToString("c"),
                         Total = ((decimal)(p.PkgBasePrice + p.PkgAgencyCommission)).ToString("c")
                     }).ToList();

                isEmpty = !packSummary.Any();
                if (isEmpty) return;

                packS = true;

                // iterate through the BookingSummary List to calculate column
                // totals for Price, Commission and Total
                decimal totBase = 0.0m;
                decimal totComm = 0.0m;
                decimal totTotl = 0.0m;
                foreach (BookingSummary pack in packSummary)
                {
                    string temp = "";
                    temp = (pack.BBasePrice).Remove(0, 1);
                    totBase += decimal.Parse(temp);
                    temp = (pack.BAgencyCommission).Remove(0, 1);
                    totComm += decimal.Parse(temp);
                    temp = (pack.Total).Remove(0, 1);
                    totTotl += decimal.Parse(temp);
                }
                //Build a dummy BookingSummary Record for the last Totals line in the table
                BookingSummary pack1 = new BookingSummary();
                pack1.BookingNo = "";
                pack1.BookingDate = "";
                pack1.Description = "";
                pack1.TripEndDate = "";
                pack1.TripEndDate = "Totals";
                pack1.BBasePrice = totBase.ToString("c");
                pack1.BAgencyCommission = totComm.ToString("c");
                pack1.Total = totTotl.ToString("c");

                packSummary.Add(pack1);

                if (packSummary != null)
                    packS = true;

                gvwTravelData1.DataSource = packSummary;    // assign Package list to GridView datasource
                gvwTravelData1.DataBind();                  // bind the GridView data

                int rowCount1 = gvwTravelData1.Rows.Count;
                // format the Totals Row
                gvwTravelData1.Rows[rowCount1 - 1].Cells[4].Font.Bold = true;
                gvwTravelData1.Rows[rowCount1 - 1].Cells[5].Font.Bold = true;
                gvwTravelData1.Rows[rowCount1 - 1].Cells[6].Font.Bold = true;
                gvwTravelData1.Rows[rowCount1 - 1].Cells[7].Font.Bold = true;
            }
        }

        // RowCreated event method for the Travel Products GridView
        protected void gvwTravelData_RowCreated(object sender, GridViewRowEventArgs e)
        {
            // on aRowCreated event, rename and center align the GridView column headers
            GridViewRow gvr = e.Row;
            if (gvr.RowType == DataControlRowType.Header)
            {
                // horizontal alignment of GridView header - possibly superfluous
                gvr.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[7].HorizontalAlign = HorizontalAlign.Center;

                // rename GridView column headers
                gvr.Cells[0].Text = "Booking Number";
                gvr.Cells[1].Text = "Booking Date";
                gvr.Cells[2].Text = "Description";
                gvr.Cells[3].Text = "Trip Start";
                gvr.Cells[4].Text = "Trip End";
                gvr.Cells[5].Text = "Base Price";
                gvr.Cells[6].Text = "Charges";
                gvr.Cells[7].Text = "Line Total";
            }
        }
        // RowCreated event method for the Travel Packages GridView
        protected void gvwTravelData1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            // on aRowCreated event, rename and center align the GridView column headers
            GridViewRow gvr = e.Row;
            if (gvr.RowType == DataControlRowType.Header)
            {
                // horizontal alignment of GridView header - possibly superfluous
                gvr.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[7].HorizontalAlign = HorizontalAlign.Center;

                // rename GridView column headers
                gvr.Cells[0].Text = "Booking Number";
                gvr.Cells[1].Text = "Booking Date";
                gvr.Cells[2].Text = "Description";
                gvr.Cells[3].Text = "Trip Start";
                gvr.Cells[4].Text = "Trip End";
                gvr.Cells[5].Text = "Base Price";
                gvr.Cells[6].Text = "Charges";
                gvr.Cells[7].Text = "Line Total";
            }
        }
    }
}
   