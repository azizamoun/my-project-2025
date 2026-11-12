
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="Visitor.details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Inter:wght@400;600&display=swap');

        body {
            font-family: 'Inter', sans-serif;
            background-color: #f3f4f6;
        }

        .product-details-card {
            width: 80%;
            max-width: 900px;
            margin: 50px auto;
            background-color: #ffffff;
            border-radius: 12px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
            display: flex;
            overflow: hidden;
        }

        .details-image {
            flex: 1;
            padding: 20px;
            background-color: #f9f9f9;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .details-image img {
            max-width: 100%;
            height: auto;
            border-radius: 8px;
        }

        .details-info {
            flex: 1;
            padding: 30px;
        }

        .details-info h2 {
            font-size: 24px;
            color: #333;
            margin-bottom: 15px;
        }

        .details-info p {
            font-size: 16px;
            margin: 8px 0;
            color: #555;
        }

        .details-info .price {
            color: #007bff;
            font-weight: 600;
            font-size: 18px;
            margin-top: 10px;
        }

        .details-info .buttons {
            margin-top: 20px;
        }

        .btn {
            padding: 10px 20px;
            margin-right: 10px;
            border: none;
            border-radius: 6px;
            background-color: #007bff;
            color: #fff;
            font-size: 14px;
            cursor: pointer;
            text-decoration: none;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        .description {
            margin-top: 20px;
            font-style: italic;
            color: #444;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="product-details-card">
        <div class="details-image">
            <asp:Image ID="Image1" runat="server" Width="300" Height="200" />
        </div>

        <div class="details-info">
            <h2>Product Details</h2>
            <p><strong>ID:</strong> <asp:Label ID="Labelid" runat="server" /></p>
            <p><strong>Name:</strong> <asp:Label ID="LabelName" runat="server" /></p>
            <p class="price"><strong>Price:</strong> <asp:Label ID="LabelPrice" runat="server" /></p>

            <div class="buttons">
                <asp:LinkButton ID="AddToCartLinkButton" runat="server" CssClass="btn" OnClick="AddToCartLinkButton_Click">Add To Cart</asp:LinkButton>
                <asp:LinkButton ID="LinkButtonBack" runat="server" CssClass="btn" OnClick="LinkButtonBack_Click">Back</asp:LinkButton>
            </div>

            <div class="description">
                <asp:Label ID="LabelDescription" runat="server" />
            </div>
        </div>
    </div>
</asp:Content> 