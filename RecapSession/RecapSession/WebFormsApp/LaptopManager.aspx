<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LaptopManager.aspx.cs" Inherits="WebFormsApp.LaptopManager" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laptop Manager</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background: linear-gradient(to right, #e0eafc, #cfdef3);
            margin: 0;
            padding: 0;
            transition: background 0.5s ease;
        }

        .container {
            max-width: 960px;
            margin: 50px auto;
            background-color: #ffffff;
            padding: 40px;
            border-radius: 12px;
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.1);
            transition: box-shadow 0.3s ease;
        }

        .container:hover {
            box-shadow: 0 12px 30px rgba(0, 0, 0, 0.15);
        }

        h2, h3 {
            color: #34495e;
            margin-bottom: 20px;
            text-align: center;
        }

        label {
            font-weight: 600;
            display: block;
            margin-bottom: 6px;
            color: #2c3e50;
        }

        input[type="text"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 6px;
            transition: border-color 0.3s ease;
        }

        input[type="text"]:focus {
            border-color: #3498db;
            outline: none;
        }

        .form-group {
            margin-bottom: 25px;
        }

        .btn {
            background-color: #3498db;
            color: white;
            padding: 12px 24px;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            font-size: 16px;
            transition: background-color 0.3s ease, transform 0.2s ease;
        }

        .btn:hover {
            background-color: #2980b9;
            transform: scale(1.05);
        }

        .gridview {
            width: 100%;
            border-collapse: collapse;
            margin-top: 30px;
            transition: all 0.3s ease;
        }

        .gridview th, .gridview td {
            border: 1px solid #ddd;
            padding: 12px;
            text-align: left;
        }

        .gridview th {
            background-color: #3498db;
            color: white;
        }

        .gridview tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .gridview tr:hover {
            background-color: #ecf0f1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Laptop Manager</h2>

            <asp:GridView ID="LaptopGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                CssClass="gridview"
                OnRowEditing="LaptopGridView_RowEditing"
                OnRowUpdating="LaptopGridView_RowUpdating"
                OnRowCancelingEdit="LaptopGridView_RowCancelingEdit"
                OnRowDeleting="LaptopGridView_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="BrandName" HeaderText="Brand" />
                    <asp:BoundField DataField="ModelName" HeaderText="Model" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="SerialNumber" HeaderText="Serial Number" ReadOnly="True"/>
                    <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <h3>Add New Laptop</h3>

            <div class="form-group">
                <label for="txtBrand">Brand</label>
                <asp:TextBox ID="txtBrand" runat="server" />
            </div>

            <div class="form-group">
                <label for="txtModel">Model</label>
                <asp:TextBox ID="txtModel" runat="server" />
            </div>

            <div class="form-group">
                <label for="txtPrice">Price</label>
                <asp:TextBox ID="txtPrice" runat="server" />
            </div>

            <div class="form-group">
                <label for="txtSerial">Serial Number</label>
                <asp:TextBox ID="txtSerial" runat="server" />
            </div>

            <div class="form-group">
                <label for="txtEmpName">Employee Name</label>
                <asp:TextBox ID="txtEmpName" runat="server" />
            </div>

            <asp:Button ID="AddLaptopButton" runat="server" Text="Add New Laptop" CssClass="btn" OnClick="AddLaptopButton_Click" />
        </div>
    </form>
</body>
</html>
