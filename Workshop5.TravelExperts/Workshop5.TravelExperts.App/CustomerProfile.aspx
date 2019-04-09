<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="Workshop5.TravelExperts.App.CustomerProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="color:blue; text-align:center">Customer Profile </h3>

    <%if (btnSaveClicked && UpdateSuccess) {%>
        <div style="position:relative; background-color:lightgreen; width:300px; left:50%; margin-left: -150px; text-align:center; height:40px; border-radius: 5px">
            <asp:Label style="display:inline-block; margin-top:10px" runat="server">Update Success</asp:Label>
        </div>
    <%} %>

    <%if (btnSaveClicked && !UpdateSuccess) {%>
        <div style="position:relative; background-color:lightsalmon; width:300px; left:50%; margin-left: -150px; text-align:center; height:40px; border-radius: 5px">
            <asp:Label style="display:inline-block; margin-top:10px" runat="server">Update Failed</asp:Label>
        </div>
    <%} %>

    <div class="customerRegistrationForm" style="background-color:lightskyblue; border-radius:5px">
        <div class="container">
            <div class="form-box">
                <div>
                    <label>Username</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="txtbox" ReadOnly="True"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtUsername" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Username is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Password</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="txtbox" ReadOnly="True" TextMode="Password"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPassword" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Password is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Confirm password</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="txtConfirm" runat="server" CssClass="txtbox" ReadOnly="True" TextMode="Password"></asp:TextBox>
                </div>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ErrorMessage="CompareValidator" ForeColor="Red" ControlToValidate="txtConfirm" Display="Dynamic" >Password does not match!</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtConfirm" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Confirm Password is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>First Name</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="txtbox" ReadOnly="True"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">First name is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Last Name</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="txtbox" ReadOnly="True"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Last name is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Address</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="txtbox" ReadOnly="True"></asp:TextBox> 
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Address is required to be filled!</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="container">
            <div class="form-box">
                <div>
                    <label>City</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="txtCity" runat="server" CssClass="txtbox" ReadOnly="True"></asp:TextBox>  
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity" ErrorMessage="RequiredFieldValidator" ForeColor="Red">City is required to be filled!</asp:RequiredFieldValidator>
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
                    <asp:TextBox ID="txtPostal" runat="server" CssClass="txtbox" ReadOnly="True"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPostal" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Postal code is required to be filled!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPostal" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} ( *\d{1}[A-Z]{1}\d{1})$">Postal code must be like A1B 2C3.</asp:RegularExpressionValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Country</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="txtCountry" runat="server" CssClass="txtbox" ReadOnly="True"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCountry" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Country is required to be filled!</asp:RequiredFieldValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Home Phone</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="txtHomePhone" runat="server" CssClass="txtbox" ReadOnly="True"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHomePhone" ErrorMessage="RequiredFieldValidator" ForeColor="Red" Display="Dynamic">Home phone is required to be filled!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHomePhone" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^\d{10}$">Phone number should be 10 digits including area code!</asp:RegularExpressionValidator>
            </div>

            <div class="form-box">
                <div>
                    <label>Business Phone</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="txtBusPhone" runat="server" CssClass="txtbox" ReadOnly="True"></asp:TextBox>
                </div>
            </div>

            <div class="form-box">
                <div>
                    <label>Email</label>
                </div>
                <div class="txt-wrapper">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
 <asp:Button ID="btnReset" runat="server" Text="Reset" Visible="false" Height="35px" Width="150px" OnClick="btnReset_Click" style="position:relative; left: 280px" CausesValidation="false" CssClass="btnLogin"/>
 <asp:Button ID="btnEdit" runat="server" Text="Edit" Height="35px" Width="150px" OnClick="btnEdit_Click" style="position:relative; left: 280px" CausesValidation="false" CssClass="btnLogin"/>
 <asp:Button ID="btnSave" runat="server" Text="Save" Height="35px" Width="150px"  OnClick="btnSave_Click" style="position:relative; left: 480px" Visible="False" CssClass="btnLogin"/>

</asp:Content>
