/********************************************************************************
* 
* Author: Tim Leslie
* Date: April 5, 2019.
* Course: CPRG 207 Rapid OOSD Threaded Project
* Assignment: Workshop 5
* Purpose: This is a collection of methods to manage Package entities and
* interact with the database.  It forms part of the
* CPRG 207 Threaded Project Workshop 5.
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
        // return a List of Package objects from the database
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

                    // if necessary, convert database null values to C# nulls
                    if (dr["PkgStartDate"] == DBNull.Value)
                        package.PkgStartDate = null;
                    else
                        package.PkgStartDate = (DateTime)dr["PkgStartDate"];

                    if (dr["PkgEndDate"] == DBNull.Value)
                        package.PkgEndDate = null;
                    else
                        package.PkgEndDate = (DateTime)dr["PkgEndDate"];

                    if (dr["PkgDesc"] == DBNull.Value)
                        package.PkgDesc = null;
                    else 
                        package.PkgDesc = (string)dr["PkgDesc"];

                    if (dr["PkgBasePrice"] == DBNull.Value)
                        package.PkgBasePrice = null;
                    else
                        package.PkgBasePrice = (decimal)dr["PkgBasePrice"];

                    if (dr["PkgAgencyCommission"] == DBNull.Value)
                        package.PkgAgencyCommission = null;
                    else
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
