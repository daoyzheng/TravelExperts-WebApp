<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Workshop5.TravelExperts.App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Image ID="Image1" ImageUrl="~/Images/download-removebg.png" runat="server" Height="143px" Width="135px" />
   <%-- <h1 style="color:blue; text-align:center">Welcom to Travel Experts</h1>--%>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large" ForeColor="Blue" Text="Welcome to Travel Experts"></asp:Label>
    <br />
    <br />
    <br />
    <div style="margin-left:75px">
    <asp:Image ID="Image2" ImageUrl="~/Images/paris.jpg" runat="server" />
    <asp:Image ID="Image3" ImageUrl="~/Images/moscow.jpg" runat="server" />
    <asp:Image ID="Image4" ImageUrl="~/Images/venice.jpg" runat="server" />
    <asp:Image ID="Image5" ImageUrl="~/Images/coliseum.jpg" runat="server" />
     </div>
    <br />
    <br />
    <br />

    <%--<div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>
   
    
</asp:Content>
