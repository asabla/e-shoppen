<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Eshoppen.Account.Admin.AddProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Label ID="lbl_HeaderText" runat="server" Text="Lägg till nya produkt" /></h2>
    <p>
        <asp:Label ID="lbl_InfoText" runat="server">
            För att lägga till en produkt så fyller du i samtliga fält här nedan. Och för att lägga till en bild för produkten så 
            görs även detta längre ner.
        </asp:Label>
    </p>
    <div>
        <fieldset>
            <legend><asp:Label ID="lbl_FieldsetLegend" runat="server" Text="Produktinformation" /></legend>
            <asp:FormView ID="FormView_newProduct" runat="server" DefaultMode="Insert" >
            <InsertItemTemplate>
            <p>
                <asp:Label ID="lbl_PTitle" runat="server" Text="Produktens titel: " /><br />
                <asp:TextBox ID="txtBox_PTitle" runat="server" Width="400" />
            </p>
            <p>
                <asp:Label ID="lbl_PInfo" runat="server" Text="Information som skall visas: " /><br />
                <asp:TextBox ID="txtBox_PInfo" runat="server" TextMode="MultiLine" Width="100%" Height="100%" />
                <asp:ResizableControlExtender ID="ResizableControlExtender1" runat="server" TargetControlID="txtBox_PInfo"
                              HandleCssClass="handleText" MinimumHeight="200" MinimumWidth="500" />
            </p>
            <p>
                <asp:Label ID="lbl_PQuantity" runat="server" Text="Antal i lager: " /><br />
                <asp:TextBox ID="txtBox_PQuantity" runat="server" Text="0" />
            </p>
            <p>
                <asp:Label ID="lbl_PTags" runat="server" Text="Skriv in taggar till produkten, separera med komma" /><br />
                <asp:TextBox ID="txtBox_PTags" runat="server" Width="400" />
            </p>
            <p>
                <asp:Label ID="lbl_PImg" runat="server" Text="Klicka på knappen nedan för att lägga till en bild" /><br />
                <asp:FileUpload ID="ImageUpload" runat="server" /><br />
                <asp:Label ID="lbl_ImgStatus" runat="server" Visible="false" />
            </p>
            <p>
                <asp:Label ID="lbl_PPrice" runat="server" Text="Priset på produkten: " /><br />
                <asp:TextBox ID="txtBox_PPrice" runat="server" />
            </p>
            <br />
            <p>
                <asp:Button ID="btn_InsertImage" runat="server" Text="Spara produkt" 
                    Height="50" Width="150" onclick="btn_InsertImage_Click" />
            </p>
            </InsertItemTemplate>
            </asp:FormView>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </fieldset>
    </div>
</asp:Content>