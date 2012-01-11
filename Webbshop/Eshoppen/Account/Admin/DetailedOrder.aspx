<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailedOrder.aspx.cs" Inherits="Eshoppen.Account.Admin.DetailedOrder" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Orderinfomation</h2>
    <br />
    <fieldset>
        <legend>Orderdetaljer</legend>
        <p>Här kan du se detaljerad information om varje order. Eller klicka <a href="MadeOrders.aspx">här</a> för att gå tillbaka.</p>
        <table>
        <asp:Repeater ID="Repeater_OrderDetails" runat="server">
            <ItemTemplate>
            <tr>
                <td>
                    <a id="linkToProduct" href='../../Sites/Product.aspx?title=<%# Eval("PTitle") %>'><asp:Label ID="lbl_Title" runat="server" Text='<%# Eval("PTitle") %>' /></a>
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
            <td><asp:Label ID="lbl_CheckStatus" runat="server" Visible="false" Text="Du kan bara ange ett alternativ" /></td>
        </tr>
        <tr>
            <td>
                <asp:CheckBoxList ID="CheckBoxList_Update" runat="server">
                    <asp:ListItem>Skickad</asp:ListItem>
                    <asp:ListItem>Ej Skickad</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td>
                <asp:Button ID="btn_UpdateOrder" runat="server" Text="Uppdatera order" onclick="btn_UpdateOrder_Click" />
            </td>
        </tr>
        </table>
    </fieldset>
</asp:Content>