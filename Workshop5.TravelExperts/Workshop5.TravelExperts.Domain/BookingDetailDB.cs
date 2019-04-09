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
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop5.TravelExperts.Data;

namespace Workshop5.TravelExperts.Domain
{
    public class BookingDetailDB
    {
        public static List<BookingDetail> GetAllBookingDetails()
        {
            List<BookingDetail> bookingDetails = new List<BookingDetail>(); // instantiate an empty List of Bookings

            SqlConnection conn = TravelExpertsDB.GetConnection(); // instantiate a DB connection object

            // prepare the SQL statement
            string selectStatement = "SELECT * FROM BookingDetails";

            SqlCommand selectCommand = new SqlCommand(selectStatement, conn);

            try
            {
                conn.Open();
                SqlDataReader dr = selectCommand.ExecuteReader();
                while (dr.Read())
                {
                    BookingDetail bookingDetail= new BookingDetail();
                    bookingDetail.BookingDetailId = (int)dr["BookingDetailId"];

                    if (dr["ItineraryNo"] == DBNull.Value)
                        bookingDetail.ItineraryNo = null;
                    else
                        bookingDetail.ItineraryNo = (double)dr["ItineraryNo"];

                    if (dr["TripStart"] == DBNull.Value)
                        bookingDetail.TripStart = null;
                    else
                        bookingDetail.TripStart = (DateTime)dr["TripStart"];

                    if (dr["TripEnd"] == DBNull.Value)
                        bookingDetail.TripEnd = null;
                    else
                        bookingDetail.TripEnd = (DateTime)dr["TripEnd"];

                    if (dr["Description"] == DBNull.Value)
                        bookingDetail.Description = null;
                    else
                        bookingDetail.Description = (string)dr["Description"];

                    if (dr["Destination"] == DBNull.Value)
                        bookingDetail.Destination = null;
                    else
                        bookingDetail.Destination = (string)dr["Destination"];

                    if (dr["BasePrice"] == DBNull.Value)
                        bookingDetail.BasePrice = null;
                    else
                        bookingDetail.BasePrice = (decimal)dr["BasePrice"];

                    if (dr["AgencyCommission"] == DBNull.Value)
                        bookingDetail.AgencyCommission = null;
                    else
                        bookingDetail.AgencyCommission = (decimal)dr["AgencyCommission"];

                    if (dr["BookingId"] == DBNull.Value)
                        bookingDetail.BookingId = null;
                    else
                        bookingDetail.BookingId = (int)dr["BookingId"];


                    bookingDetail.RegionId = (string)dr["RegionId"];
                    bookingDetail.ClassId = (string)dr["ClassId"];
                    bookingDetail.FeeId = (string)dr["FeeId"];

                    if (dr["ProductSupplierId"] == DBNull.Value)
                        bookingDetail.ProductSupplierId= null;
                    else
                        bookingDetail.ProductSupplierId = (int)dr["ProductSupplierId"];

                    bookingDetails.Add(bookingDetail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return bookingDetails;
        }
    }
}
