<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Eshoppen.Account.Settings" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Inställningar</h2>
    <p>Här kan du ändra dina inställningar för kontot. Allting ifrån leveransadress till att ändra lösenord</p>
    <p>För att ändra lösenord gå vidare till denna <a href="ChangePassword.aspx">sida</a></p>
    <fieldset>
        <legend>KontoUppgifter</legend>
        <p>
            <asp:Label ID="lbl_Firstname" runat="server" Text="Förnamn: " /><br />
            <asp:TextBox ID="txtBox_Firstname" runat="server" />
        </p>
        <p>
            <asp:Label ID="lbl_Lastname" runat="server" Text="Efternamn: " /><br />
            <asp:TextBox ID="txtBox_Lastname" runat="server" />
        </p>
        <p>
            <asp:Label ID="lbl_City" runat="server" Text="Stad: " /><br />
            <asp:TextBox ID="txtBox_City" runat="server" />
        </p>
        <p>
            <asp:Label ID="lbl_Address" runat="server" Text="Adress: " /><br />
            <asp:TextBox ID="txtBox_Address" runat="server" />
        </p>
        <p>
            <asp:Label ID="lbl_Zipcode" runat="server" Text="Postnummer: " /><br />
            <asp:TextBox ID="txtBox_ZipCode" runat="server" />
        </p>
        <p>
            <asp:Button ID="btn_SaveSettings" runat="server" Text="Spara inställningar" 
                onclick="btn_SaveSettings_Click" />
        </p>
    </fieldset>
</asp:Content>
