<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HandleProducts.aspx.cs" Inherits="Eshoppen.Account.Admin.HandleProducts" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Label ID="lbl_HandleProduct" runat="server" Text="Hantering av produkter"></asp:Label></h2>
    <p>
        <asp:Label ID="lbl_PageInfo" runat="server">
            Här har du möjlighet till att hantera befintliga produkter, lika väl som att lägga till nya. 
            För att lägga till nya produkter så följer du bara denna 
            <asp:HyperLink ID="HyperLink_NewProducts" runat="server" NavigateUrl="~/Account/Admin/AddProduct.aspx" Text=" länk" />
        </asp:Label>    
    </p>
    <div>
        <fieldset>
            <legend><asp:Label ID="lbl_FieldSetLegend" runat="server" Text="Produkter som inte finns i lager" /></legend>
            <p>
                <asp:Label ID="lbl_FieldSetInfo" runat="server">
                    För att göra det lättare för dig som administratör så återfinns alla produkter som inte finns
                    i lagret under listan här nedan. För att fylla på så är det bara skriva i antalet som skall fyllas
                    på och klicka sedan på uppdatera.
                </asp:Label>
            </p>
            <br />
            <div>
            <table style="margin-left:5px; margin-right:5px">
                <asp:Repeater ID="Repeater_OutOfStock" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <a href='../../Sites/Product.aspx?title=<%# Eval("PTitle") %>'><asp:Label ID="lbl_ProductTitle" runat="server" Text='<%# Eval("PTitle") %>' /></a>
                            </td>
                            <td style="width:20px" />
                            <td>
                                <asp:Label ID="lbl_Productquant" runat="server" Text="Antal: " /><asp:TextBox ID="txtBox_Quantity" runat="server" Text='<%# Eval("PInStock") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td>
                        <asp:Button ID="btn_UpdateProducts" runat="server" Text="Uppdatera produkter" 
                            onclick="btn_UpdateProducts_Click" />
                    </td>
                </tr>
            </table>
            </div>
        </fieldset>
    </div>
</asp:Content>