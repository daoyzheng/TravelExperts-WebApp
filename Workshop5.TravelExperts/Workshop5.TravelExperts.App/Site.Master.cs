using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop5.TravelExperts.Data;

namespace Workshop5.TravelExperts.App {
    public partial class SiteMaster : MasterPage {
        public string custName { get; set; }
        protected void Page_Load(object sender, EventArgs e) {
            if(Session["Customer"] != null) {
                Customer cust = (Customer)Session["Customer"];
                custName = $"{cust.CustFirstName} {cust.CustLastName}";
            }
        }
    }
}