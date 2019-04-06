<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerOrders.aspx.cs" Inherits="Workshop5.TravelExperts.App.CustomerOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Customer Travel Summary</h1>
        <p class="lead">Welcome to Travel Experts. Thank you for working with us to serve your travel needs.
        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Travel Summary</h2>
            <table>
              <tr>
                  <td><asp:GridView ID="gvwTravelData" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Width="829px">
                      <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                      <EditRowStyle BackColor="#999999" />
                      <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                      <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                      <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                      <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                      <SortedAscendingCellStyle BackColor="#E9E7E2" />
                      <SortedAscendingHeaderStyle BackColor="#506C8C" />
                      <SortedDescendingCellStyle BackColor="#FFFDF8" />
                      <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                      </asp:GridView>
                      <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
                  </td>
              </tr>
            </table>
        </div>
    </div>
</asp:Content>

