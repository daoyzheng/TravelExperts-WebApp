using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workshop5.TravelExperts.Data;
using Workshop5.TravelExperts.Domain;

namespace Workshop5.TravelExperts.App {
    public partial class CustomerProfile : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e)
        {
            RequiredFieldValidator8.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator5.Enabled = false;
            RequiredFieldValidator6.Enabled = false;
            RequiredFieldValidator7.Enabled = false;
            RequiredFieldValidator11.Enabled = false;
            RequiredFieldValidator3.Enabled = false;

            ////need to find customer information based on who is in the session and display it. 

            // Grab Customer session if user logged in
            if (Session["Customer"] != null)
            {
                Customer cust = (Customer)Session["Customer"];
                txtUsername.Text = cust.UserName.ToString();
                txtPassword.Text = cust.Password.ToString();
                txtFirstName.Text = cust.CustFirstName.ToString();
                txtLastName.Text = cust.CustLastName.ToString();
                txtAddress.Text = cust.CustAddress.ToString();
                txtCity.Text = cust.CustCity.ToString();
                DropDownList1.Text = cust.CustProv.ToString();
                txtPostal.Text = cust.CustPostal.ToString();
                txtCountry.Text = cust.CustCountry.ToString();
                txtHomePhone.Text = cust.CustHomePhone.ToString();
                txtBusPhone.Text = cust.CustBusPhone.ToString();
                txtEmail.Text = cust.CustEmail.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e) //btnSave
        {
            //if edit is clicked make save visable

            //if anything changed, update DB


        }

        protected void btnCancel_Click(object sender, EventArgs e)//btnCancel
        {
            //when cancel btn is clicked exit out of "edit mode" and any changes will not be saved

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true; //when we hit the edit btn the save btn becombes visable

            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtCity.ReadOnly = false;
            DropDownList1.Enabled = true;//province
            txtPostal.ReadOnly = false;
            txtCountry.ReadOnly = false;
            txtHomePhone.ReadOnly = false;
            txtBusPhone.ReadOnly = false;
            txtEmail.Enabled = true; 
            txtUsername.ReadOnly = false;
            txtPassword.ReadOnly = false;

            RequiredFieldValidator8.Enabled = true;
            RequiredFieldValidator4.Enabled = true;
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator5.Enabled = true;
            RequiredFieldValidator6.Enabled = true;
            RequiredFieldValidator7.Enabled = true;
            RequiredFieldValidator11.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
        }
    }
}