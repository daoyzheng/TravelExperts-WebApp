/********************************************************************************
* 
* Author: Tim Leslie
* Date: April 5, 2019.
* Course: CPRG 207 Rapid OOSD Threaded Project
* Assignment: Workshop 5
* Purpose: This is a collection of methods for managing database interactions
* with the Bookings table and forms part of the CPRG 207
* Threaded Project Workshop 5.
*
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop5.TravelExperts.Data;

namespace Workshop5.TravelExperts.Domain
{
    public class BookingDB
    {
        // returns a List of Booking objects from the database
        public static List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>(); // instantiate an empty List of Bookings

            SqlConnection conn = TravelExpertsDB.GetConnection(); // instantiate a DB connection object

            // prepare the SQL statement
            string selectStatement = "SELECT * FROM Bookings";

            SqlCommand selectCommand = new SqlCommand(selectStatement, conn);

            try
            {
                conn.Open();
                SqlDataReader dr = selectCommand.ExecuteReader();
                while (dr.Read())
                {
                    Booking booking = new Booking();

                    booking.BookingId = (int)dr["BookingId"];

                    // convert DB null values to C# nulls
                    if (dr["BookingDate"] == DBNull.Value)
                        booking.BookingDate = null;
                    else
                        booking.BookingDate = (DateTime)dr["BookingDate"];

                    if (dr["BookingNo"] == DBNull.Value)
                        booking.BookingNo = null;
                    else
                        booking.BookingNo = (string)(dr["BookingNo"]);

                    if (dr["TravelerCount"] == DBNull.Value)
                        booking.TravelerCount = null;
                    else
                        booking.TravelerCount = (double)(dr["TravelerCount"]);

                    if (dr["CustomerId"] == DBNull.Value)
                        booking.CustomerId = null;
                    else
                        booking.CustomerId = (int)(dr["CustomerId"]);

                    if (dr["TripTypeId"] == DBNull.Value)
                        booking.TripTypeId = null;
                    else
                        booking.TripTypeId = (string)(dr["TripTypeId"]);


                    if (dr["PackageId"] == DBNull.Value)
                        booking.PackageId = null;
                    else
                        booking.PackageId = (int)(dr["PackageId"]);

                    bookings.Add(booking);
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
            return bookings;
        }
    }
}
