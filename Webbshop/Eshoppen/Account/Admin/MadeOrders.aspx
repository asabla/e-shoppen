<%@ Page Title="Made orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MadeOrders.aspx.cs" Inherits="Eshoppen.Account.Admin.MadeOrders" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Välkommen administratör!</h2>
    <p>
        Här inne har du möjligheten som administratör se över beställda ordrar, för att sedan även kunna godkänna eller tabort dem.
         Du har även möjlighet till att se över tidigare genomförda ordrar.
    </p>
    <br />
    
    <fieldset>
        <legend>Ordrar som väntar på att godkännas</legend>
        <p>Dessa ordrar måste du som administratör gå igenom, för att godkänna en leverans så går du bara in på en av dem i listan nedan.</p>
        <asp:Repeater ID="Repeater_unDelivered" runat="server">
            <ItemTemplate>
            <a id='linkToDetails_<%# Eval("id") %>' href='DetailedOrder.aspx?orderid=<%# Eval("id") %>&orderdate=<%# Eval("orderdate") %>&user=<%# Eval("username") %>'>
            <table>
                <tr>
                    <td><b>Datum:</b> <asp:Label ID="lbl_OrderDate" runat="server" Text='<%# Eval("orderdate") %>' /></td>
                    <td style="width:20px" />
                    <td><b>User:</b> <asp:Label ID="lbl_Username" runat="server" Text='<%# Eval("username") %>' /></td>
                    <td style="width:20px" />
                    <td><b>Summa:</b> <asp:Label ID="lbl_TotalPrice" runat="server" Text='<%# Eval("TotalPrice") %>' /></td>
                </tr>
            </table>
            </a>
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
    <br />

    <fieldset>
        <legend>Ordrar som godkänts</legend>
        <p>
            Välj mellan vilka datum här nedan som du vill se ordrar ifrån. Tänk dock på att när du väljer ett datum så kommer den 
            att se ut som följande (ex) 2012-01-06 00:00:00. Så ordrar som har kommit in efter kl 00:00 kommer inte visas. Dessa kan 
            du se om du väljer dagen efter (lathet att inte ha fixat detta).
        </p>
        <table>
            <tr>
                <td>
                    <asp:Calendar ID="Calendar_Startdate" runat="server" 
                        onselectionchanged="Calendar_Startdate_SelectionChanged" />
                </td>
                <td style="width:70px" />
                <td>
                    <asp:Calendar ID="Calendar_Enddate" runat="server"
                        onselectionchanged="Calendar_Enddate_SelectionChanged" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Repeater ID="Repeater_Delivered" runat="server">
            <ItemTemplate>
            <a id='linkToDetails_<%# Eval("id") %>' href='DetailedOrder.aspx?orderid=<%# Eval("id") %>&orderdate=<%# Eval("orderdate") %>&user=<%# Eval("username") %>'>
            <table>
                <tr>
                    <td><b>Datum:</b> <asp:Label ID="lbl_OrderDate" runat="server" Text='<%# Eval("orderdate") %>' /></td>
                    <td style="width:20px" />
                    <td><b>User:</b> <asp:Label ID="lbl_Username" runat="server" Text='<%# Eval("username") %>' /></td>
                    <td style="width:20px" />
                    <td><b>Summa:</b> <asp:Label ID="lbl_TotalPrice" runat="server" Text='<%# Eval("TotalPrice") %>' /></td>
                </tr>
            </table>
            </a>
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
</asp:Content>