


<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Visitor.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Inter:wght@400;600&display=swap');

        body {
            font-family: 'Inter', sans-serif;
            background-color: #f9f9f9;
        }

        .product-grid {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
            gap: 30px;
            padding: 40px;
            justify-content: center;
        }

        .product-card {
            background-color: white;
            border-radius: 12px;
            padding: 20px;
            box-shadow: 0 6px 18px rgba(0, 0, 0, 0.06);
            text-align: center;
            transition: transform 0.2s ease;
        }

        .product-card:hover {
            transform: translateY(-5px);
        }

        .product-card img {
            width: 100%;
            height: 200px;
            object-fit: contain;
            border-radius: 8px;
            margin-bottom: 15px;
        }

        .product-name {
            font-size: 18px;
            color: #333;
            font-weight: 600;
            margin-bottom: 5px;
        }

        .product-price {
            font-size: 16px;
            color: #007bff;
            margin-bottom: 15px;
        }

        .product-button {
            display: inline-block;
            margin: 5px;
            padding: 10px 18px;
            border: none;
            border-radius: 6px;
            background-color: #007bff;
            color: white;
            font-size: 14px;
            cursor: pointer;
            text-decoration: none;
        }

        .product-button:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-grid">
        <asp:DataList ID="DataListProducts" runat="server" RepeatColumns="3" OnItemCommand="DataListProducts_ItemCommand">
            <ItemTemplate>
                <div class="product-card">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# GetImageUrl(Eval("ImageStr")) %>'  Height="300" Width="300"/>
                    <div class="product-name">
                        <%# Eval("Name") %>
                    </div>
                    <div class="product-price">
                        Price: <%# Eval("Price") %> ILS
                    </div>

                    <asp:Label ID="Labelid" runat="server" Text='<%# Eval("ID") %>' Visible="False" />

                    <asp:LinkButton ID="detailsLinkButton" runat="server" CommandName="Details" CommandArgument='<%# Eval("ID") %>' CssClass="product-button">Details</asp:LinkButton>

                    <asp:LinkButton ID="LinkButtonAddToCart" runat="server" CommandName="AddToCart" CommandArgument='<%# Eval("ID") %>' CssClass="product-button">Add To Cart</asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
