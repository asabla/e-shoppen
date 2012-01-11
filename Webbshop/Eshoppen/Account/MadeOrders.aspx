<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MadeOrders.aspx.cs" Inherits="Eshoppen.Account.MadeOrders" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Detaljerad orderinfo</h2>
    <p>Här kan du se mer detaljerad information om just din order. Eller klicka <asp:HyperLink ID="HyperLink_GoBack" runat="server" NavigateUrl="~/Account/MyProfile.aspx">här</asp:HyperLink> för att gå tillbaka till mina sidor</p>
    <br />
    <fieldset>
        <legend>Beställda varor</legend>
        <table>
        <asp:Repeater ID="Repeater_OrderDetails" runat="server">
            <ItemTemplate>
            <tr>
                <td>
                    <a id="linkToProduct" href='../Sites/Product.aspx?title=<%# Eval("PTitle") %>'><asp:Label ID="lbl_Title" runat="server" Text='<%# Eval("PTitle") %>' /></a>
                </td>
                <td style="width:15px;" />
                <td>
                    <b>antal:</b> <asp:Label ID="lbl_quantity" runat="server" Text='<%# Eval("quantity") %>' />
                </td>
                <td style="width:175px;" />
                <td>
                    <b>á Pris:</b> <asp:Label ID="lbl_Price" runat="server" Text='<%# Eval("PPrice") %>' />
                </td>
            </tr>
            </ItemTemplate>
            <SeparatorTemplate>
            <tr>
                <td colspan="5"><hr /></td>
            </tr>
            </SeparatorTemplate>
        </asp:Repeater>
            <tr>
                <td colspan="5"><hr /></td>
            </tr>
            <tr>
                <td></td><td></td><td></td><td></td>
                <td>
                    <!--Kanske används senare?<b>TotalPris:</b>-->
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>