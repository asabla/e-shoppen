<%@ Page Title="Produkter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Eshoppen.Sites.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Produkter</h2>
    <asp:Label ID="lbl_webbService" runat="server"></asp:Label><br />
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" SiteMapProvider="main" />
    <hr />
    <table>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <tr id='productID_<%# Eval("PId") %>'>
            <td rowspan="2">
                <asp:Image ID="img_Product" runat="server" Width="90" Height="90" ImageUrl='<%# Eval("PImgurl") %>' />
            </td>
            <td>
                <p>Produktnamn: <a class="ProductLink" href='Product.aspx?title=<%# Eval("PTitle") %>'><asp:Label ID="productTitle" runat="server" Text='<%# Eval("PTitle") %>'></asp:Label></a></p>
            </td>
        </tr>
        <tr>
            <td>
                <p>Produktinfo: <asp:Label ID="productInfo" runat="server" Text='<%# Eval("PInfo") %>'></asp:Label></p>
                <p>Pris: <asp:Label ID="productPrice" runat="server" Text='<%# Eval("PPrice") %>'></asp:Label></p>
            </td>
        </tr>
        </ItemTemplate>
        <SeparatorTemplate>
            <tr>
                <td colspan="2">
                    <br /><hr /><br />
                </td>
            </tr>
        </SeparatorTemplate>
    </asp:Repeater>
    </table>
</asp:Content>