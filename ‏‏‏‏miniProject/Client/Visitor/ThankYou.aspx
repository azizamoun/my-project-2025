


<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="thankYou.aspx.cs" Inherits="Visitor.thankYou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        background: #121212;
        margin: 0;
        padding: 50px 0;
        display: flex;
        justify-content: center;
        align-items: center;
        min-height: 100vh;
    }
    .thankyou-container {
        background: #1e1e1e;
        max-width: 480px;
        width: 100%;
        padding: 40px;
        border-radius: 12px;
        box-shadow: 0 8px 24px rgba(0,0,0,0.9);
        color: #eee;
        text-align: center;
    }
    .thankyou-container img {
        width: 150px;
        height: auto;
        margin-bottom: 25px;
        filter: brightness(0) invert(1);
    }
    .thankyou-title {
        font-size: 2.8rem;
        font-weight: 700;
        margin-bottom: 20px;
        color: #ffffff; /* changed accent color to white */
        letter-spacing: 1.2px;
    }
    .thankyou-text {
        font-size: 1.2rem;
        line-height: 1.5;
        margin: 15px 0;
        color: #ccc;
    }
    .label-highlight {
        color: #ffffff; /* white accent */
        font-weight: 600;
    }
    .notice {
        margin-top: 25px;
        font-size: 1rem;
        font-style: italic;
        color: #999;
    }
    @media (max-width: 520px) {
        .thankyou-container {
            padding: 30px 25px;
        }
        .thankyou-title {
            font-size: 2rem;
        }
        .thankyou-text {
            font-size: 1rem;
        }
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="thankyou-container">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/mercedes logo 19.png"  Width="400" Height="150"/>
        
        <h1 class="thankyou-title">
            Thank You, 
            <asp:Label ID="fullNameLabel" runat="server" CssClass="label-highlight" Text="Customer"></asp:Label>!
        </h1>
        
        <p class="thankyou-text">We appreciate your purchase from our site.</p>
        
        <p class="thankyou-text">
            <span class="label-highlight">Order Number:</span> 
            <asp:Label ID="orderNumberLabel" runat="server" Text="12345"></asp:Label>
        </p>
        
        <p class="thankyou-text">
            <span class="label-highlight">Total Price:</span> 
            <asp:Label ID="totalLabel" runat="server" Text="0.00 ILS"></asp:Label>
        </p>
        
        <p class="thankyou-text">
            <span class="label-highlight">Delivery Address:</span><br />
            <asp:Label ID="addressLabel" runat="server" Text="Your Address"></asp:Label>
        </p>
        
        <p class="notice">
            You will receive your order within two weeks.
        </p>
        
        <p class="notice">
            <asp:Label ID="DateLabel" runat="server" Text=""></asp:Label>
        </p>
    </div>

</asp:Content>