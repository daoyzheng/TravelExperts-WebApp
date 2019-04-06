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

                // Three table LINQ join to extract relevant Fields.
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
                // iterate through the BookingSummary List to calculate column
                // totals for Price, Commission and Total
                decimal totBase = 0.0m;
                decimal totComm = 0.0m;
                decimal totTotl = 0.0m;
                foreach(BookingSummary book in bookSummary)
                {
                    string temp = "";
                    temp = (book.BBasePrice).Remove(0,1);
                    totBase += decimal.Parse(temp);
                    temp = (book.BAgencyCommission).Remove(0, 1);
                    totComm += decimal.Parse(temp);
                    temp = (book.Total).Remove(0, 1);
                    totTotl += decimal.Parse(temp);
                }
                // Concoct dummy BookingSummary Record for last Totals line in table
                BookingSummary book1 = new BookingSummary();
                book1.BookingNo = "";
                book1.BookingDate = "";
                book1.Description = "";
                book1.TripStartDate = "";
                book1.TripEndDate = "Totals";
                book1.BBasePrice = totBase.ToString("c");
                book1.BAgencyCommission = totComm.ToString("c");
                book1.Total = totTotl.ToString("c");

                bookSummary.Add(book1);

                gvwTravelData.DataSource = bookSummary;


                gvwTravelData.DataBind();

                

                //gvwTravelData

                //                gvwTravelData.Columns["TripStartDate"].DefaultCellStyle = "c";

                //BoundField fieldStartDate = gvwTravelData.Columns[3] as BoundField;
                //fieldStartDate.DataFormatString = "{D}";
                //gvwTravelData.DataBind();

                //                gvwTravelData.Columns[4].ItemStyle.Width = 100;

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

        protected void gvwTravelData_PreRender(object sender, EventArgs e)
        {
            

        }

        protected void gvwTravelData_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvr = e.Row;
            if (gvr.RowType == DataControlRowType.Header)
            {
                gvr.Cells[0].Text = "Booking Number";
                gvr.Cells[1].Text = "Booking Date";
                gvr.Cells[2].Text = "Description";
                gvr.Cells[3].Text = "Trip Start";
                gvr.Cells[4].Text = "Trip End";
                gvr.Cells[5].Text = "Base Price";
                gvr.Cells[6].Text = "Commission";
                gvr.Cells[7].Text = "Line Total";
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
   