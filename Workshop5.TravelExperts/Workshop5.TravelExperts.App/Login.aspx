<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Workshop5.TravelExperts.App.Login" %>

<%--/*
    * Term 2 Threaded Project 
    * Author : Mahda Kazemian
    * Date : April 03,2019
    * Course Name : Threaded Project for OOSD
    * Module : PROJ-207-OOSD
    * Purpose : Login page
    */--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="position:relative;">
       <img src="Images/download-removebg.png" alt="Icon" height="60" width="60" style="display:block; margin: 40px auto 20px"/>
       <h3 style="text-align:center; color:blue">Sign in to Travel Experts</h3><br />
    </div>

    <%if (ValidLogin == false) {%>
        <div style="position:relative; background-color:lightsalmon; width:300px; left:50%; margin-left: -150px; text-align:center; height:40px; border-radius: 5px">
            <asp:Label style="display:inline-block; margin-top:10px" runat="server">Incorrect username and/or password</asp:Label>
        </div>
    <%} %>

    <div class="jumbotron" style="position:relative; width:390px; top:5px; left:50%; margin-left:-195px; background-color:lightblue;">
       <div style="text-align:center">
            <table style="display:inline-block">
                <tr>
                    <td style="text-align:left; padding-bottom:3px">Username</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox style="margin-bottom:20px" ID="uxUser" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left; padding-bottom:3px">Password</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="uxPass" runat="server" Width="240px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button  ID="uxLogin" runat="server" Height="35px" Width="200px" Text="Login" OnClick="uxLogin_Click" CssClass="btnLogin"/>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 7px">Need an account? <a href="CustomerRegistration.aspx">Create an account</a></td>
                </tr>
            </table>
       </div>
    </div>
</asp:Content>
