using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop5.TravelExperts.Data;
using Workshop5.TravelExperts.Domain;

namespace Workshop5.TravelExperts.App
{
   /*
  * Term 2 Threaded Project 
  * Author : Mahda Kazemian
  * Date : April 03,2019
  * Course Name : Threaded Project for OOSD
  * Module : PROJ-207-OOSD
  * Purpose : login buttton to login existing customer
  */
    public partial class Login : System.Web.UI.Page {
        public bool ValidLogin { get; set; }
        protected void Page_Load(object sender, EventArgs e) {
            ValidLogin = true;
        }

        protected void uxLogin_Click(object sender, EventArgs e)
        {

            string uname = Convert.ToString(uxUser.Text);
            string pass = Convert.ToString(uxPass.Text);
            if (CustomerDB.Login(uname, pass))
            {
                //if customer already exist 
                Customer cust = CustomerDB.Find(uname);
                Session["Customer"] = cust;
                Response.Redirect("~/CustomerOrders.aspx");
                
            }
            else
            {
                //if customer did not register
                Session["Customer"] = null;
                ValidLogin = false;
                //Response.Write("Username or Password is not correct.");
                //Response.Write("<script>alert('Username or Password is not correct.')</script>");
            }

        }
    }
}