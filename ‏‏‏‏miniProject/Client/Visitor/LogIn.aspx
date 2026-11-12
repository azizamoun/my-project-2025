

<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Visitor.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Inter:wght@400;600&display=swap');

        html, body {
            height: 100%;
            margin: 0;
            font-family: 'Inter', sans-serif;
            background-color: #f8f9fa;
        }

        .login-container {
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            background: #ffffff;
        }

        .login-card {
            background: #ffffff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 400px;
            color: #333;
        }

        .login-card h2 {
            text-align: center;
            margin-bottom: 24px;
            font-weight: 600;
            color: #212529;
        }

        .login-input {
            width: 100%;
            padding: 12px;
            margin: 10px 0;
            background: #f1f3f5;
            border: 1px solid #ced4da;
            border-radius: 8px;
            font-size: 16px;
            color: #212529;
        }

        .login-input::placeholder {
            color: #888;
        }

        .login-input:focus {
            border-color: #0d6efd;
            background: #ffffff;
            outline: none;
        }

        .toggle-password {
            float: right;
            margin-right: 10px;
            margin-top: -36px;
            position: relative;
            z-index: 2;
            cursor: pointer;
            font-size: 13px;
            color: #0d6efd;
        }

        .login-button {
            width: 100%;
            background-color: #0d6efd;
            color: white;
            border: none;
            padding: 14px;
            font-size: 16px;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.3s;
            margin-top: 12px;
        }

        .login-button:hover {
            background-color: #0b5ed7;
        }

        .login-message {
            margin-top: 15px;
            color: #dc3545;
            text-align: center;
        }

        @media (max-width: 480px) {
            .login-card {
                padding: 30px 20px;
            }
        }
    </style>

    <script type="text/javascript">
        function togglePassword() {
            var pwd = document.getElementById('<%= TextBox2.ClientID %>');
            if (pwd.type === "password") {
                pwd.type = "text";
            } else {
                pwd.type = "password";
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-container">
        <div class="login-card">
            <h2>Login</h2>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="login-input" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="login-input" placeholder="Password" TextMode="Password"></asp:TextBox>
            <span class="toggle-password" onclick="togglePassword()">Show/Hide</span>
            <asp:Button ID="Button1" runat="server" CssClass="login-button" Text="Login" OnClick="Button1_Click" />
            <asp:Label ID="Label1" runat="server" CssClass="login-message"></asp:Label>
        </div>
    </div>
</asp:Content>