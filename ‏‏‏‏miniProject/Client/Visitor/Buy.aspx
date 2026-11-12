

<%@ Page Title="Payment" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="buy.aspx.cs" Inherits="Visitor.buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Inter:wght@400;600;700&display=swap');

        body {
            font-family: 'Inter', sans-serif;
            background: linear-gradient(to right, #f0f4f8, #e0eafc);
        }

        .payment-wrapper {
            display: flex;
            justify-content: center;
            align-items: center;
            padding: 60px 15px;
        }

        .payment-card {
            background: rgba(255, 255, 255, 0.8);
            backdrop-filter: blur(15px);
            border-radius: 20px;
            padding: 40px;
            box-shadow: 0 12px 40px rgba(0, 0, 0, 0.1);
            max-width: 500px;
            width: 100%;
        }

        .payment-card h2 {
            font-size: 26px;
            font-weight: 700;
            color: #111;
            text-align: center;
            margin-bottom: 30px;
        }

        .form-group {
            margin-bottom: 22px;
            position: relative;
        }

        .form-label {
            display: block;
            font-weight: 600;
            margin-bottom: 6px;
            color: #333;
        }

        .form-input {
            width: 100%;
            padding: 14px 16px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 12px;
            background-color: #fff;
            transition: border 0.2s ease;
        }

        .form-input:focus {
            border-color: #007BFF;
            outline: none;
        }

        .cvv-icon-toggle {
            position: absolute;
            right: 14px;
            top: 50%;
            transform: translateY(-50%);
            background: none;
            border: none;
            cursor: pointer;
            font-size: 18px;
            color: #666;
        }

        .cvv-icon-toggle:hover {
            color: #007BFF;
        }

        .total-box {
            font-size: 18px;
            font-weight: 600;
            color: #222;
            background: #f0f0f0;
            padding: 10px 14px;
            border-radius: 10px;
            display: inline-block;
        }

        .payment-button {
            width: 100%;
            padding: 15px;
            font-size: 16px;
            font-weight: 600;
            background-color: #007BFF;
            color: white;
            border: none;
            border-radius: 12px;
            transition: background-color 0.3s ease;
        }

        .payment-button:hover {
            background-color: #0056b3;
        }

        @media (max-width: 480px) {
            .payment-card {
                padding: 24px;
            }
        }
    </style>

    <script>
        function toggleCVV() {
            const input = document.getElementById('<%= cvvTextBox.ClientID %>');
            const icon = document.getElementById('cvvEyeIcon');
            if (input.type === "password") {
                input.type = "text";
                icon.className = "fa fa-eye-slash";
            } else {
                input.type = "password";
                icon.className = "fa fa-eye";
            }
        }
    </script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="payment-wrapper">
        <div class="payment-card">
            <h2>Secure Payment</h2>

            <div class="form-group">
                <label class="form-label">ID Number</label>
                <asp:TextBox ID="TextBoxID" runat="server" CssClass="form-input" />
            </div>

            <div class="form-group">
                <label class="form-label">Address</label>
                <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="form-input" />
            </div>

            <div class="form-group">
                <label class="form-label">Total</label><br />
                <span class="total-box">
                    <asp:Label ID="totalLabel" runat="server" /> ILS
                </span>
            </div>

            <div class="form-group">
                <label class="form-label">Card Number</label>
                <asp:TextBox ID="visaTextBox" runat="server" CssClass="form-input" placeholder="XXXX-XXXX-XXXX-XXXX" />
            </div>

            <div class="form-group">
                
                <label class="form-label">CVV</label>
                <asp:TextBox ID="cvvTextBox" runat="server" CssClass="form-input" TextMode="Password" placeholder="123" />
                <button type="button" class="cvv-icon-toggle" onclick="toggleCVV()">
                    <i id="cvvEyeIcon" class="fa fa-eye"></i>
                </button>
            </div>

            <asp:Button ID="BuyBtn" runat="server" Text="Pay & Save" CssClass="payment-button" OnClick="BuyBtn_Click" />
        </div>
    </div>
</asp:Content>