<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Eshoppen.Sites.Search" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Label ID="lbl_Searchlbl" runat="server" Text="Sökresultat" /></h2>
    <div>
        <asp:Label ID="lbl_ResultString" runat="server" />
        <hr />
        <br />
        <table style="width:100%">
            <asp:Repeater ID="Repeater_SearchResult" runat="server">
                <ItemTemplate>
                <tr>
                    <td style="width:50px">
                        <asp:Label ID="lbl_ResultNumber" runat="server" />
                    </td>
                    <td>
                        <a href='Product.aspx?title=<%# Eval("PTitle") %>'><asp:Label ID="lbl_ProductTitle" runat="server" Text='<%# Eval("PTitle") %>' /></a>    
                    </td>
                </tr>
                </ItemTemplate>
                <SeparatorTemplate>
                    <tr>
                        <td colspan="2"><hr /></td>
                    </tr>
                </SeparatorTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>