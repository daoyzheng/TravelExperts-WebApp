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

        public List<Package> packages = new List<Package>();
        public List<Booking> bookings = new List<Booking>();
        public List<BookingDetail> bookingDetails = new List<BookingDetail>();
        public Customer cust = new Customer();

        public bool bookS = false;
        public bool packS = false;

        public string custName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Customer"] != null)
            {
                cust = (Customer)Session["Customer"];
                custName = $"{cust.CustFirstName} {cust.CustLastName}";
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }

            if (!IsPostBack)
            {
                packages = PackageDB.GetAllPackages();
                bookings = BookingDB.GetAllBookings();
                bookingDetails = BookingDetailDB.GetAllBookingDetails();

                // Two table LINQ join to extract relevant Fields.
                List<BookingSummary> bookSummary =
                    (from b in bookings
                     join bd in bookingDetails on b.BookingId equals bd.BookingId
                     where b.CustomerId == cust.CustomerId
                     select new BookingSummary
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
                if (!isEmpty) // if there are Travel Products execute the following block
                {
                    bookS = true;

                    // iterate through the BookingSummary List to calculate column
                    // totals for Price, Commission and Total
                    decimal totBase1 = 0.0m;
                    decimal totComm1 = 0.0m;
                    decimal totTotl1 = 0.0m;
                    foreach (BookingSummary book in bookSummary)
                    {
                        string temp = "";
                        temp = (book.BBasePrice).Remove(0, 1);
                        totBase1 += decimal.Parse(temp);
                        temp = (book.BAgencyCommission).Remove(0, 1);
                        totComm1 += decimal.Parse(temp);
                        temp = (book.Total).Remove(0, 1);
                        totTotl1 += decimal.Parse(temp);
                    }

                    //                List<BookingSummary> newList = bookSummary.OrderBy(b => b.BookingDate).ToList();
                    List<BookingSummary> newList = bookSummary.OrderByDescending(b => b.BookingDate).ToList();

                    // Concoct dummy BookingSummary Record for last Totals line in table
                    BookingSummary book1 = new BookingSummary();
                    book1.BookingNo = "";
                    book1.BookingDate = "";
                    book1.Description = "";
                    book1.TripStartDate = "";
                    book1.TripEndDate = "Totals";
                    book1.BBasePrice = totBase1.ToString("c");
                    book1.BAgencyCommission = totComm1.ToString("c");
                    book1.Total = totTotl1.ToString("c");

                    newList.Add(book1);

                    gvwTravelData.DataSource = newList;


                    gvwTravelData.DataBind();

                    //                gvwTravelData.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;

                    int rowCount = gvwTravelData.Rows.Count;
                    //                gvwTravelData.Rows[rowCount - 1].Cells[3].;

                    gvwTravelData.Rows[rowCount - 1].Cells[4].Font.Bold = true;
                    gvwTravelData.Rows[rowCount - 1].Cells[5].Font.Bold = true;
                    gvwTravelData.Rows[rowCount - 1].Cells[6].Font.Bold = true;
                    gvwTravelData.Rows[rowCount - 1].Cells[7].Font.Bold = true;

                    gvwTravelData.HeaderRow.HorizontalAlign = HorizontalAlign.Center;
                }
                // Two table LINQ join to extract relevant Fields.
                //List<PackageSummary> packSummary =
                //    (from b in bookings
                //     join p in packages on b.PackageId equals p.PackageId
                //     where b.CustomerId == cust.CustomerId
                //     select new PackageSummary
                //     {
                //         PackageId = p.PackageId.ToString(),
                //         PkgName = p.PkgName,
                //         PkgDescription = p.PkgDesc,
                //         PkgStartDate = ((DateTime)p.PkgStartDate).ToString("d"),
                //         PkgEndDate = ((DateTime)p.PkgEndDate).ToString("d"),
                //         PBasePrice = ((decimal)(p.PkgBasePrice)).ToString("c"),
                //         PAgencyCommission = ((decimal)(p.PkgAgencyCommission)).ToString("c"),
                //         Total = ((decimal)(p.PkgBasePrice + p.PkgAgencyCommission)).ToString("c")
                //     }).ToList();

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
                // Concoct dummy BookingSummary Record for last Totals line in table
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

                gvwTravelData1.DataSource = packSummary;

                gvwTravelData1.DataBind();

                int rowCount1 = gvwTravelData1.Rows.Count;

                gvwTravelData1.Rows[rowCount1 - 1].Cells[4].Font.Bold = true;
                gvwTravelData1.Rows[rowCount1 - 1].Cells[5].Font.Bold = true;
                gvwTravelData1.Rows[rowCount1 - 1].Cells[6].Font.Bold = true;
                gvwTravelData1.Rows[rowCount1 - 1].Cells[7].Font.Bold = true;
            }
        }


        protected void gvwTravelData_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvr = e.Row;
            if (gvr.RowType == DataControlRowType.Header)
            {
                gvr.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[7].HorizontalAlign = HorizontalAlign.Center;

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

        protected void gvwTravelData1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //GridViewRow headerRow = gvwTravelData.HeaderRow;
            //headerRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            GridViewRow gvr = e.Row;
            if (gvr.RowType == DataControlRowType.Header)
            {
                gvr.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[7].HorizontalAlign = HorizontalAlign.Center;

                gvr.Cells[0].Text = "Booking Number";
                gvr.Cells[1].Text = "Booking Date";
                gvr.Cells[2].Text = "Description";
                gvr.Cells[3].Text = "Trip Start";
                gvr.Cells[4].Text = "Trip End";
                gvr.Cells[5].Text = "Base Price";
                gvr.Cells[6].Text = "Charges";
                gvr.Cells[7].Text = "Line Total";

                //gvr.Cells[0].Text = "Package Id";
                //gvr.Cells[1].Text = "Package Name";
                //gvr.Cells[2].Text = "Package Start Date";
                //gvr.Cells[3].Text = "Package End Date";
                //gvr.Cells[4].Text = "Package Description";
                //gvr.Cells[5].Text = "Base Price";
                //gvr.Cells[6].Text = "Commission";
                //gvr.Cells[7].Text = "Line Total";

                gvr.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                gvr.Cells[7].HorizontalAlign = HorizontalAlign.Center;


            }

        }

    }
}
   