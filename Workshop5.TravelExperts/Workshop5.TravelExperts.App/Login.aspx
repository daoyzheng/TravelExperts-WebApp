<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Workshop5.TravelExperts.App.Login" %>

<%--/*
    * Term 2 Threaded Project 
    * Author : Mahda Kazemian
    * Date : April 03,2019
    * Course Name : Threaded Project for OOSD
    * Module : PROJ-207-OOSD
    * Purpose :Login page
    */--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="position:relative; width:390px; top:25px; left:50%; margin-left:-175px; background-color:lightblue;">
       <h3 style="text-align:center">Sign in to Travel Experts</h3><br />
       <div style="text-align:center">
            <table style="display:inline-block">
                <tr>
                    <td style="text-align:left">Username</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox style="margin-bottom:20px" ID="uxUser" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left">Password</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="uxPass" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button style="margin-top:40px; background-color:limegreen; border-style:none" ID="uxLogin" runat="server" Height="35px" Width="200px" Text="Login" OnClick="uxLogin_Click" />
                    </td>
                </tr>
                <tr>
                    <td>Need an account? <a href="CustomerRegistration.aspx">Create an account</a></td>
                </tr>
            </table>
       </div>
    </div>
</asp:Content>
