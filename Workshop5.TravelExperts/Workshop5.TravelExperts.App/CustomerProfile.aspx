<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="Workshop5.TravelExperts.App.CustomerProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <br />
    <h3 style="color:blue">Customer Profile </h3>
    <br />
    <br />

    <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
<table style="width: 784px">

    <tr>
        <td style="width: 152px ; color:blue">Change Username </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="txtUsername" runat="server"  CssClass="col-xs-offset-0" ReadOnly="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtUsername" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Username is required to be filled!</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; height: 22px; color:blue"> Change Password </td>
        <td style="width: 578px; height: 22px;" class="modal-sm">
            <asp:TextBox ID="txtPassword" runat="server" ReadOnly="True"></asp:TextBox>
<%--            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxPassword" ErrorMessage="RequiredFieldValidator" ForeColor="Red"></asp:RequiredFieldValidator>--%>
        </td>
   </tr>
<%--    <tr>
        <td style="width: 152px; height: 21px; color:blue"> Confirm new password </td>
        <td class="modal-sm" style="width: 578px; height: 21px;">
            <asp:TextBox ID="txtConfirm" runat="server"></asp:TextBox>
         
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ErrorMessage="CompareValidator" ForeColor="Red" ControlToValidate="lblConfirm" Display="Dynamic" >Password does not match!</asp:CompareValidator>
         
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxConfirm" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Confirm Password is required!</asp:RequiredFieldValidator>      
        </td>
    </tr>--%>
    <tr>
        <td style="width: 152px; height: 22px; color:blue">First Name  </td>
        <td style="width: 578px; height: 22px;" class="modal-sm">
            <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">First name is required!</asp:RequiredFieldValidator>
        </td>
    </tr>
     <tr>
        <td style="width: 152px; height: 22px; color:blue"> Last Name</td>
        <td style="width: 578px; height: 22px;" class="modal-sm">
        <asp:TextBox ID="txtLastName" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Last name is required!</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Address </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="txtAddress" runat="server" ReadOnly="True"></asp:TextBox> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Address is required!</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">City </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="txtCity" runat="server" ReadOnly="True"></asp:TextBox>  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity" ErrorMessage="RequiredFieldValidator" ForeColor="Red">City is required!</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Province  </td>
        <td style="width: 578px" class="modal-sm">
            <%--<asp:TextBox ID="uxProvince" runat="server"></asp:TextBox>--%>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="174px" Enabled="False">
                <asp:ListItem Value="0">select province</asp:ListItem>
                <asp:ListItem Value="AB">Alberta</asp:ListItem>
                <asp:ListItem Value="BC">British Columbia</asp:ListItem>
                <asp:ListItem Value="MB">Manitoba</asp:ListItem>
                <asp:ListItem Value="NB">New Brunswick</asp:ListItem>
                <asp:ListItem Value="NL">Newfoundland</asp:ListItem>
                <asp:ListItem Value="NS">Nova Scotia</asp:ListItem>
                <asp:ListItem Value="ON">Ontario</asp:ListItem>
                <asp:ListItem Value="PE">Prince Edward Island</asp:ListItem>
                <asp:ListItem Value="QC">Quebec</asp:ListItem>
                <asp:ListItem Value="SK">Saskatchewan</asp:ListItem>
            </asp:DropDownList>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownList1" ErrorMessage="RequiredFieldValidator" ForeColor="Red" InitialValue="0">Province is required!</asp:RequiredFieldValidator>

        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Postal Code  </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="txtPostal" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPostal" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Postal code is required!</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPostal" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} ( *\d{1}[A-Z]{1}\d{1})$">Postal code must be like A1B 2C3.</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Country </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="txtCountry" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCountry" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Country is required!</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; height: 22px; color:blue">Home Phone </td>
        <td style="height: 22px; width: 578px;">
            <asp:TextBox ID="txtHomePhone" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHomePhone" ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic">Home phone is required!</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHomePhone" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^\d{10}$">Phone number should be 10 digits including area code!</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Business Phone </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="txtBusPhone" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Email </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
</table>
<br />
<br />
<br />
<br />
<br />
 <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Visible="False" BorderStyle="Groove" />
<br />
<br />
</asp:Content>
