using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Workshop5.TravelExperts.App
{
    /*
    * Term 2 Threaded Project 
    * Author : Mahda Kazemian
    * Date : April 03,2019
    * Course Name : Threaded Project for OOSD
    * Module : PROJ-207-OOSD
    * Purpose :Logout page
    */
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Customer"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}