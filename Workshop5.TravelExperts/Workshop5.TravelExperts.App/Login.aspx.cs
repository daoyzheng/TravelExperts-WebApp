using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop5.TravelExperts.Domain;

namespace Workshop5.TravelExperts.App {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void uxLogin_Click(object sender, EventArgs e)
        {

            string un = Convert.ToString(uxUser.Text);
            if (!(CustomerDB.CheckUserName(un)))
            {
                //if customer already exist 
                int CustID = CustomerDB.Find(un);
                Session["Customer"] = CustID;
                Response.Redirect("~/CustomerProfile.aspx");

            }
            else
            {
                //if customer did not register
                Session["Customer"] = null;
                //Response.Redirect("~/CustomerRegistration.aspx");
                Response.Write("You need to register first");
            }

        }
    }
}