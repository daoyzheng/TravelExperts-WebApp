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
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop5.TravelExperts.Data;

namespace Workshop5.TravelExperts.Domain
{
    public class PackageDB
    {
        public static List<Package> GetAllPackages()
        {
            List<Package> packages = new List<Package>(); // instantiate an empty List of Bookings

            SqlConnection conn = TravelExpertsDB.GetConnection(); // instantiate a DB connection object

            // prepare the SQL statement
            string selectStatement = "SELECT * FROM Packages";

            SqlCommand selectCommand = new SqlCommand(selectStatement, conn);

            try
            {
                conn.Open();
                SqlDataReader dr = selectCommand.ExecuteReader();
                while (dr.Read())
                {
                    Package package = new Package();
                    package.PackageId = (int)dr["PackageId"];
                    package.PkgName = (string)dr["PkgName"];
                    package.PkgStartDate = (DateTime)dr["PkgStartDate"];
                    package.PkgEndDate = (DateTime)dr["PkgEndDate"];
                    package.PkgDesc = (string)dr["PkgDesc"];
                    package.PkgBasePrice = (decimal)dr["PkgBasePrice"];
                    package.PkgAgencyCommission = (decimal)dr["PkgAgencyCommission"];
                    packages.Add(package);
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

            return packages;

        }

    }
}
