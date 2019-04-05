<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerRegistration.aspx.cs" Inherits="Workshop5.TravelExperts.App.CustomerRegistration" %>
<%--/*
    * Term 2 Threaded Project 
    * Author : Mahda Kazemian
    * Date : April 03,2019
    * Course Name : Threaded Project for OOSD
    * Module : PROJ-207-OOSD
    * Purpose :registration page
    */--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3 style="color:blue">Welcome to registration </h3>
    <%--<asp:Image ID="Image1" ImageUrl="~/Images/Register.jpg" runat="server" />--%>
    <br />
    <br />
<table style="width: 784px">

    <tr>
        <td style="width: 152px ; color:blue">Username </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="uxUsername" runat="server"  CssClass="col-xs-offset-0"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="uxUsername" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Username is required to be filled!</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; height: 22px; color:blue"> Password </td>
        <td style="width: 578px; height: 22px;" class="modal-sm">
            <asp:TextBox ID="uxPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxPassword" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Password is required to be filled!</asp:RequiredFieldValidator>
        </td>
   </tr>
    <tr>
        <td style="width: 152px; height: 21px; color:blue"> Confirm password </td>
        <td class="modal-sm" style="width: 578px; height: 21px;">
            <asp:TextBox ID="uxConfirm" runat="server"></asp:TextBox>
         
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="uxPassword" ErrorMessage="CompareValidator" ForeColor="Red" ControlToValidate="uxConfirm" Display="Dynamic" >Password does not match!</asp:CompareValidator>
         
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxConfirm" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Confirm Password is required to be filled!</asp:RequiredFieldValidator>
         
        </td>

    </tr>
    <tr>
        <td style="width: 152px; height: 22px; color:blue">First Name  </td>
        <td style="width: 578px; height: 22px;" class="modal-sm">
            <asp:TextBox ID="uxFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxFirstName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">First name is required to be filled!</asp:RequiredFieldValidator>
        </td>
    </tr>
     <tr>
        <td style="width: 152px; height: 22px; color:blue"> Last Name  </td>
        <td style="width: 578px; height: 22px;" class="modal-sm">
        <asp:TextBox ID="uxLastName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxLastName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Last name is required to be filled!</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Address </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="uxAddress" runat="server"></asp:TextBox> 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="uxAddress" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Address is required to be filled!</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">City </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="uxCity" runat="server"></asp:TextBox>  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="uxCity" ErrorMessage="RequiredFieldValidator" ForeColor="Red">City is required to be filled!</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Province  </td>
        <td style="width: 578px" class="modal-sm">
            <%--<asp:TextBox ID="uxProvince" runat="server"></asp:TextBox>--%>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="174px">
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

            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownList1" ErrorMessage="RequiredFieldValidator" ForeColor="Red" InitialValue="0">Province is required to be filled!</asp:RequiredFieldValidator>

        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Postal Code  </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="uxPostal" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="uxPostal" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Postal code is required to be filled!</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="uxPostal" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} ( *\d{1}[A-Z]{1}\d{1})$">Postal code must be like A1B 2C3.</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Country </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="uxCountry" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxCountry" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Country is required to be filled!</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; height: 22px; color:blue">Home Phone </td>
        <td style="height: 22px; width: 578px;">
            <asp:TextBox ID="uxHomePhone" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uxHomePhone" ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic">Home phone is required to be filled!</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="uxHomePhone" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^\d{10}$">Phone number should be 10 digits including area code!</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Business Phone </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="uxBusPhone" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 152px; color:blue">Email </td>
        <td style="width: 578px" class="modal-sm">
            <asp:TextBox ID="uxEmail" runat="server"></asp:TextBox>
        </td>
    </tr>


</table>
<br />
<br />
<br />
<br />
<br />
    <asp:Button ID="uxSubmit" runat="server" Text="Submit" OnClick="uxSubmit_Click" />


<br />
<br />

    

</asp:Content>
