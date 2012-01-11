<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Eshoppen._Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Välkommen till e-shoppen
    </h2>
    
    <div id="slideshow" class="slideshow">
        <asp:Repeater ID="Repeater_Slideshow" runat="server">
            <ItemTemplate>
            <div>
                <table>
                    <tr>
                        <td rowspan="3">
                            <a href='Sites/Product.aspx?title=<%# Eval("PTitle") %>'>
                            <asp:Image ID="ProductImage" ImageUrl='<%# Eval("PImgurl") %>' runat="server" 
                                Width="120px" Height="110px" meta:resourcekey="ProductImageResource1" /></a>
                        </td>
                        <td>
                            <a href='Sites/Product.aspx?title=<%# Eval("PTitle") %>'><b>
                            <asp:Label ID="lbl_ProductTitle" runat="server" Text='<%# Eval("PTitle") %>' 
                                meta:resourcekey="lbl_ProductTitleResource1" /></b></a>
                        </td>
                    </tr>
                    <tr>
                        <td>Pris: <asp:Label ID="lbl_ProductPrice" runat="server" 
                                Text='<%# Eval("PPrice") %>' meta:resourcekey="lbl_ProductPriceResource1" /></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lbl_ProductDescription" runat="server" 
                                Text='<%# Eval("PInfo") %>' 
                                meta:resourcekey="lbl_ProductDescriptionResource1" /></td>
                    </tr>
                </table>
            </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
        <br />
        <hr />
        <br />
    <div>
        <asp:Repeater ID="Repeater_Products" runat="server">
            <ItemTemplate>
            <a href='Sites/Product.aspx?title=<%# Eval("PTitle") %>'>
                <div class="DisplayProducts">
                    <b><asp:Label ID="lbl_PTitle" runat="server" Text='<%# Eval("PTitle") %>' 
                        meta:resourcekey="lbl_PTitleResource1" /></b>
                    <p><asp:Image ID="ProductsImages" CssClass="ProducImage" runat="server" 
                            DescriptionUrl='<%# Eval("PImgurl") %>' ImageUrl='<%# Eval("PImgurl") %>' 
                            meta:resourcekey="ProductsImagesResource1" /></p>
                    <asp:Label ID="lbl_Pricelabel" runat="server" Text="Pris: " 
                        meta:resourcekey="lbl_PricelabelResource1" /><asp:Label ID="lbl_PPrice" 
                        runat="server" Text='<%# Eval("PPrice") %>' 
                        meta:resourcekey="lbl_PPriceResource1" />
                </div>
            </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
