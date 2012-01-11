<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Eshoppen.Sites.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table>
    <tr>
        <td>
            <h2><asp:label ID="lbl_ProductTitle" runat="server" /></h2>    
        </td>
    </tr>
    <tr>
        <td rowspan="4">
            <asp:Image Height="300px" Width="300" ID="img_Product" runat="server" />
        </td>
        <td>
            <p><asp:Label ID="lbl_productnrlabel" runat="server" Text="Produktnummer: " /><asp:Label ID="lbl_ProductNr" runat="server" /></p>
        </td>
        <td rowspan="2">
            <asp:Button ID="btn_addToCart" runat="server" Height="70px" Width="180px" Text="Lägg i kundvagnen" onclick="btn_addToCart_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <p><asp:Label ID="lbl_productpricelabel" runat="server" Text="Pris: " /><asp:Label ID="lbl_ProductPrice" runat="server" />kr</p>
        </td>
    </tr>
    <tr>
        <td>
            <p><asp:Label ID="lbl_productstocklabel" runat="server" Text="I Lager: " /><asp:Label ID="lbl_ProductInStock" runat="server" /></p>
        </td>
        <td rowspan="2">
            <asp:Button ID="btn_UpdateQuantity" runat="server" Text="Uppdatera lagerstatus" Height="70px" Width="180px"
                        onclick="btn_UpdateQuantity_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <p><asp:Label ID="lbl_productquantitylabel" runat="server" Text="Antal: " /><asp:TextBox ID="txtbox_quantity" runat="server" Text="1" /></p>
        </td>
    </tr>
</table>
<div>
    <fieldset>
        <legend>Produktinformation: </legend>
        <p><asp:Label ID="lbl_ProductInfo" runat="server" /></p>
    </fieldset>
</div>
    <p><asp:Label ID="lbl_TestQuery" runat="server" /></p>
</asp:Content>