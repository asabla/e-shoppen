<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Eshoppen.Sites.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Varukorgen</h2>
    <hr />
    <asp:Label ID="lbl_Test" runat="server" />
    <asp:Repeater ID="Repeater_cart" runat="server">
        <ItemTemplate>
            <p><b>Produkt:</b> <a id="LinkToProduct" href='Product.aspx?title=<%# Eval("ProductName") %>'><asp:Label ID="lbl_ProductName" runat="server" Text='<%# Eval("ProductName") %>' /></a></p>
            <p>Produktnummer: <asp:Label ID="lbl_ProudctID" runat="server" Text='<%# Eval("ProductID") %>' /></p>
            <p>Antal: <asp:TextBox ID="txtBox_Quantity" runat="server" Text='<%# Eval("Quantity") %>' /></p>
        </ItemTemplate>
        <SeparatorTemplate>
            <hr />
        </SeparatorTemplate>
    </asp:Repeater>
    <br />
    <hr />
    <br />
    <p><b>Totaltpris:</b> <asp:Label ID="lbl_TotalPrice" runat="server" /></p>
    <br /><br />
    <table>
        <tr>
            <td>
                <asp:Button ID="btn_ClearCart" runat="server" Text="Rensa kundvagnen" 
                    onclick="btn_ClearCart_Click" />
            </td>
            <td style="width:50px;" />
            <td>
                <asp:Button ID="btn_UpdateCart" runat="server" Text="Uppdatera kundvagnen" 
                    onclick="btn_UpdateCart_Click" />
            </td>
            <td style="width:120px" />
            <td>
                <asp:Button ID="btn_CheckForOrder" runat="server" Text="Bekräfta köp" 
                    onclick="btn_CheckForOrder_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
