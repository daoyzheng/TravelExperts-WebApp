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
    <br />
    <br />
   
    <asp:Image ID="Image1" ImageUrl="~/Images/login.jpg" runat="server" />
    <br />
    <br />
    <br />
    <table>
        <tr>
            <td style="width: 102px; color:blue">Username </td>
            <td>
                <asp:TextBox ID="uxUser" runat="server" Width="145px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 102px; color:blue">Password</td>
            <td>
                <asp:TextBox ID="uxPass" runat="server" Width="145px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <asp:Button ID="uxLogin" runat="server" Text="Login" OnClick="uxLogin_Click" />
    <br />
    <br />
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CustomerRegistration.aspx">Register here !</asp:HyperLink>

</asp:Content>
