<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Eshoppen.Sites.About" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Label ID="lbl_about" runat="server" Text="Om sidan" 
            meta:resourcekey="lbl_aboutResource1" /></h2>
    <p>
    <asp:Label ID="lbl_aboutText" runat="server" 
            meta:resourcekey="lbl_aboutTextResource1">I och med att marknaden för programvara har exploredat på senare år så skapade vi en central plats för att införskaffa 
    dessa. </asp:Label>
    </p>
    <asp:Button ID="btn_changeCulture" runat="server" Text="Change you MF culture" 
        onclick="btn_changeCulture_Click" />
</asp:Content>
