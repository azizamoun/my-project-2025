


<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Visitor.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #fafafa;
        }
        .cart-container {
            max-width: 900px;
            margin: 40px auto;
            background: #fff;
            padding: 30px;
            border-radius: 12px;
            box-shadow: 0 8px 20px rgba(0,0,0,0.1);
        }
        .cart-table {
            width: 100%;
            border-collapse: collapse;
        }
        .cart-table th, 
        .cart-table td {
            padding: 14px 18px;
            text-align: center;
            border-bottom: 1px solid #ddd;
        }
        .cart-table th {
            background-color: #222;
            color: #fff;
            font-weight: 600;
            text-transform: uppercase;
            letter-spacing: 0.05em;
        }
        .cart-table tr:hover {
            background-color: #f5f5f5;
        }
        .cart-table img {
            border-radius: 8px;
            max-width: 90px;
            height: auto;
        }
        .cart-total {
            margin-top: 20px;
            text-align: right;
            font-size: 20px;
            color: #b11313;
            font-weight: 700;
        }
        .btn-buy {
            margin-top: 25px;
            background-color: #b11313;
            color: white;
            padding: 12px 28px;
            font-size: 16px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            display: inline-block;
            text-decoration: none;
        }
        .btn-buy:hover {
            background-color: #7e0e0e;
        }
        .delete-button {
            color: #b11313;
            background: none;
            border: none;
            cursor: pointer;
            font-weight: 600;
            text-transform: uppercase;
            font-size: 14px;
        }
        .delete-button:hover {
            text-decoration: underline;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="cart-container">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="cart-table" OnRowDeleting="GridView1_RowDeleting" ShowHeader="true">
            <Columns>
                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CssClass="delete-button" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-HorizontalAlign="Center" />

                <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-HorizontalAlign="Center" />

                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Center" />

                <asp:TemplateField HeaderText="Image" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# GetImageUrl(Eval("ImageStr")) %>' Width="90" Height="90" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="cart-total">
            Total: <asp:Label ID="Label1" runat="server"></asp:Label> ILS
        </div>

        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn-buy" OnClick="LinkButton1_Click">Go To Buy</asp:LinkButton>
    </div>
</asp:Content>
