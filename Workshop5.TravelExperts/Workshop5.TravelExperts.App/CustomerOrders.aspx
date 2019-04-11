<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerOrders.aspx.cs" Inherits="Workshop5.TravelExperts.App.CustomerOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%/********************************************************************************
* 
* Author: Tim Leslie
* Date: April 5, 2019.
* Course: CPRG 207 Rapid OOSD Threaded Project
* Assignment: Workshop 5
* Purpose: This is html asp code for the CustomerOrders page.
*
*********************************************************************************/
%>
<!--    <div class="jumbotron">
        <p class="lead">Welcome to Travel Experts. Thank you for working with us to serve your travel needs.

    </div> -->

    <div class="row">
        <div style ="width:100%; margin:50px">
            <% if (bookS == true)
                {%>
                <h4><%=custName%>, here is your Travel Product Summary:</h4>
                <%} %>
            <%else { %>
                <h4><%=custName%>, you have no Travel Products, Yet!</h4>
            <%} %>

            <table style="width:100%; text-align:center">
              <tr>
                  <th style ="text-align:center"></th>
              </tr>
              <tr>
                  <td style="width:100%; text-align:center">
                      <asp:GridView ID="gvwTravelData" runat="server" HeaderStyle-CssClass="text-center"  CellPadding  ="20" ForeColor="#333333" GridLines="Vertical" HorizontalAlign="Center" Width="100%" OnRowCreated="gvwTravelData_RowCreated" AllowSorting="True" >
                         <%--<Columns>
                              <asp:BoundField HeaderStyle-HorizontalAlign="Center" />
                          </Columns>--%>
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" HorizontalAlign="Center" />
                      <EditRowStyle BackColor="#999999" HorizontalAlign="Center" Width="50px" />
                      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                      <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                      <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                      <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                      <SortedAscendingCellStyle BackColor="#E9E7E2" />
                      <SortedAscendingHeaderStyle BackColor="#506C8C" HorizontalAlign="Center" />
                      <SortedDescendingCellStyle BackColor="#FFFDF8" />
                      <SortedDescendingHeaderStyle BackColor="#6F8DAE" HorizontalAlign="Center" />
                      </asp:GridView>
<!--                      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource> -->
                  </td>
              </tr>
            </table>

            <div style="width:100%">
            <% if (packS == true)
                {%>
                <h4><%=custName%>, here is your Travel Package Summary:</h4>
                <%} %>
            <table style="width:100%">
              <tr>
                  <th style="text-align:center"></th>
              </tr>               
                  <tr>
                  <td>
                      <asp:GridView ID="gvwTravelData1" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Vertical" OnRowCreated="gvwTravelData1_RowCreated">
                          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <EditRowStyle BackColor="#999999" />
                          <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                          <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Center" />
                          <SortedAscendingCellStyle BackColor="#E9E7E2" />
                          <SortedAscendingHeaderStyle BackColor="#506C8C" />
                          <SortedDescendingCellStyle BackColor="#FFFDF8" />
                          <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                      </asp:GridView>
                  </td>
              </tr>
          </table>
          </div>
        </div>
    </div>
</asp:Content>

