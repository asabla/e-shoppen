<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="Eshoppen.Account.MyProfile" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Min sida</h2>
    <p>
        Här inne kan du som användare se tidigare köp, och leveranser som väntar. Du kan även ändra inställningar för ditt konto.
        Så som namn, adress o.s.v. Om du vill ändra lösenord för ditt konto så måste du gå in under inställningar och där ifrån 
        ställa in detta. Dessvärre så erbjuder vi inte några möjligheter idag att ändra e-mail adress. Men kommer inom snar framtid
         att uppdatera och tillåta detta.
    </p>
    <br />
    <h2>Inställningar</h2>
    <p>För att ändra inställningar så följ denna <asp:HyperLink ID="HyperLink_Settings" NavigateUrl="~/Account/Settings.aspx" runat="server">Länk</asp:HyperLink></p>
    <br />
    <br />
    <h2>Beställningar</h2>
    <fieldset>
        <legend>Väntar på bekräftelse</legend>
        <p>Dessa ordrar har ännu inte behandlats. Men du kommer ta emot ett mail så fort det har hänt något med din order</p>
        <asp:Repeater ID="Repeater_unDelivered" runat="server">
            <ItemTemplate>
                <a id='orderlink_<%# Eval("id") %>' href='MadeOrders.aspx?orderid=<%# Eval("id") %>&orderdate=<%# Eval("orderdate") %>'>
                    <asp:Label ID="lbl_Orderid" runat="server" Text='<%# Eval("id") %>' Visible="false" />
                    <table>
                        <tr>
                            <td>
                                <b>Datum:</b> <asp:Label ID="lbl_OrderDate" runat="server" Text='<%# Eval("orderdate") %>' />
                            </td>
                            <td style="width:10px" />
                            <td>
                                <b>Summa:</b> <asp:Label ID="lbl_OrderPrice" runat="server" Text='<%# Eval("TotalPrice") %>' />
                            </td>
                        </tr>
                    </table>
                </a>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Panel ID='Panel_OrderDetail' runat="server" Visible="false">
            <p>Testtext</p>
        </asp:Panel>
    </fieldset>
    <br />
    <fieldset>
        <legend>Levererade ordrar</legend>
        <p>Här kan du se alla dina tidigare ordrar. Klicka bara på någon utav länkarna för att se mer information</p>
        <asp:Repeater ID="Repeater_Delivered" runat="server">
            <ItemTemplate>
                <a id='orderlink_<%# DataBinder.Eval(Container.DataItem, "id") %>' href='MadeOrders.aspx?orderid=<%# DataBinder.Eval(Container.DataItem, "id") %>&orderdate=<%# DataBinder.Eval(Container.DataItem, "orderdate") %>'>
                    <asp:Label ID="lbl_Orderid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>' Visible="false" />
                    <table>
                        <tr>
                            <td>
                                <b>Datum:</b> <asp:Label ID="lbl_OrderDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderdate") %>' />
                            </td>
                            <td style="width:10px" />
                            <td>
                                <b>Summa:</b> <asp:Label ID="lbl_OrderPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalPrice") %>' />
                            </td>
                        </tr>
                    </table>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
</asp:Content>