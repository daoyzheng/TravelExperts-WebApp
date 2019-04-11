/********************************************************************************
* 
* Author: Tim Leslie
* Date: April 5, 2019.
* Course: CPRG 207 Rapid OOSD Threaded Project
* Assignment: Workshop 5
* Purpose: This is a PackageSummary class definition and forms part of the
* CPRG 207 Threaded Project Workshop 5.
*
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop5.TravelExperts.Data
{
    public class PackageSummary
    {
        public string PackageId { get; set; }
        public string PkgName { get; set; }
        public string PkgStartDate { get; set; }
        public string PkgEndDate { get; set;}
        public string PkgDescription { get; set; }
        public string PBasePrice { get; set; }
        public string PAgencyCommission { get; set; }
        public string Total { get; set; }
    }
}
