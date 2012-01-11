<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="Eshoppen.Account.Order" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Bekräfta köp</h2>
    <p>Se till att kontrollera uppgifterna här nedan för att beställa</p>
    <fieldset>
        <legend>KundUppgifter</legend>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl_FirstName" runat="server" Text="Förnamn: " /><br />
                    <asp:TextBox ID="txtBox_FirstName" runat="server" />
                </td>
                <td style="width:60px;" />
                <td>
                    <asp:Label ID="lbl_LastName" runat="server" Text="Efternamn: " /><br />
                    <asp:TextBox ID="txtBox_LastName" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_City" runat="server" Text="Stad: " /><br />
                    <asp:TextBox ID="txtBox_City" runat="server" />
                </td>
                <td style="width:60px;" />
                <td>
                    <asp:Label ID="lbl_Address" runat="server" Text="Adress: " /><br />
                    <asp:TextBox ID="txtBox_Address" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_ZipAddress" runat="server" Text="Postnummer: " /><br />
                    <asp:TextBox ID="txtBox_ZipAddress" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_SaveToProfile" runat="server" Text="Spara till Profil" 
                        onclick="btn_SaveToProfile_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset>
        <legend>Varor</legend>
        <asp:Repeater ID="Repeater_cart" runat="server">
            <ItemTemplate>
                <p><b>Produkt:</b> <asp:Label ID="lbl_ProductName" runat="server" Text='<%# Eval("ProductName") %>' /></p>
                <p>Produktnummer: <asp:Label ID="lbl_ProudctID" runat="server" Text='<%# Eval("ProductID") %>' /></p>
                <p>Antal: <asp:Label ID="lbl_Quantity" runat="server" Text='<%# Eval("Quantity") %>' /></p>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btn_GoBackToCart" runat="server" 
                        Text="Gå tillbaka till varukorgen" onclick="btn_GoBackToCart_Click" />
                </td>
                <td style="width:140px;" />
                <td>
                    <asp:Button ID="btn_MakeDeal" runat="server" Text="Bekräfta köpet" 
                        onclick="btn_MakeDeal_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>