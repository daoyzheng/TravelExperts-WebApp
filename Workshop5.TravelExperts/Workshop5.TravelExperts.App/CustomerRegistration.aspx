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
    <h3 style="color:dodgerblue; text-align:center">Customer Registration </h3>
    <%--<asp:Image ID="Image1" ImageUrl="~/Images/Register.jpg" runat="server" />--%>
    <br />
    <br />

    <div class="customerRegistrationForm" style="background-color:lightskyblue; border-radius:5px">
        <div class="container" >
            <div class="form-box">
                <div>
                    <label>Username</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxUsername" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="uxUsername" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Username is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Password</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxPassword" runat="server" CssClass="txtbox" TextMode="Password"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="uxPassword" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Password is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Confirm password</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxConfirm" runat="server" CssClass="txtbox" TextMode="Password"></asp:TextBox>
                </div>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="uxPassword" ErrorMessage="CompareValidator" ForeColor="Red" ControlToValidate="uxConfirm" Display="Dynamic" >Password does not match!</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="uxConfirm" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Confirm Password is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>First Name</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxFirstName" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="uxFirstName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">First name is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Last Name</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxLastName" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="uxLastName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Last name is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Address</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxAddress" runat="server" CssClass="txtbox"></asp:TextBox> 
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="uxAddress" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Address is required to be filled!</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="container">
            <div class="form-box">
                <div>
                    <label>City</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxCity" runat="server" CssClass="txtbox"></asp:TextBox>  
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="uxCity" ErrorMessage="RequiredFieldValidator" ForeColor="Red">City is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Province</label>
                </div>
                <div class="txt-wrapper">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="DropDownList1" ErrorMessage="RequiredFieldValidator" ForeColor="Red" InitialValue="0">Province is required to be filled!</asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-box">
                <div>
                    <label>Postal Code</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxPostal" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="uxPostal" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Postal code is required to be filled!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="uxPostal" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} ( *\d{1}[A-Z]{1}\d{1})$">Postal code must be like A1B 2C3.</asp:RegularExpressionValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Country</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxCountry" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="uxCountry" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Country is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Home Phone</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxHomePhone" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uxHomePhone" ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic">Home phone is required to be filled!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="uxHomePhone" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^\d{10}$">Phone number should be 10 digits including area code!</asp:RegularExpressionValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Business Phone</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxBusPhone" runat="server" CssClass="txtbox"></asp:TextBox>
                </div>
            </div>

            <div class="form-box">
                <div>
                    <label>Email</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="uxEmail" runat="server" CssClass="txtbox" TextMode="Email"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="uxClear" runat="server" Text="Clear" Height="35px" Width="200px" OnClick="uxClear_Click" style="position:relative; left: 280px" CssClass="btnLogin" CausesValidation="false"/>
    <asp:Button ID="uxSubmit" runat="server" Text="Create an account" Height="35px" Width="200px" OnClick="uxSubmit_Click" CssClass="btnLogin" style="position:relative; left:400px"/>
</asp:Content>
