<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Workshop5.TravelExperts.App.Contact" %>
 <%--* Term 2 Threaded Project 
    * Author : Mahda Kazemian
    * Date : April 03,2019
    * Course Name : Threaded Project for OOSD
    * Module : PROJ-207-OOSD
    * Purpose :contact page--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <%-- <h2><%: Title %>.</h2>--%>
    <%--<h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>--%>

   
<br />
<br />
    <asp:Image ID="Image1" ImageUrl="~/Images/contact.jpg" runat="server" style="margin-left:50px"/>
<h3 style="color:blue; margin-left:50px">Main office :</h3>
<br />
<p style="color:#072176; margin-left:50px">
    608 9 ST, SW <br />
    Calgary, AB <br />
    T2P 2P3 <br /><br />
    Email:<a href="mailto:Info@Travelexperts.com">Info@Travelexperts.com</a>
    <br /><br />
    Tell : (403)500 8010<br />
    Fax : (403)500 1020<br />             
</p>
        
<h3 style="color:blue;  margin-left:50px">Agents information:</h3><br />
        
<p style="color:#072176;  margin-left:50px">
Blinda Thompson<br />   
Tel:(403)500 8011<br />  
Email:<a href="mailto:Blinda@Travelexperts.com">Blinda@Travelexperts.com</a>   
<br /><br />     
Rosina Richmond<br />   
Tel:(403)500 8012
Email:<a href="mailto:Rosina@Travelexperts.com">Rosina@Travelexperts.com</a>
<br /><br />    
Tim Gibson<br />
Tel:(403)500 8013<br />
Email:<a href="mailto:Tim@Travelexperts.com">Tim@Travelexperts.com</a>
   
</p>

</asp:Content>
