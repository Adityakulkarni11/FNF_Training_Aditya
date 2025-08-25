<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LoginTask.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        form {
            width: 400px;
            margin: 80px auto;
            padding: 30px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        h1 {
            text-align: center;
            color: #333;
        }

        p {
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .aspNetDisabled {
            background-color: #eee;
        }

        .validator {
            color: IndianRed;
            font-size: 0.85em;
            display: block;
            margin-top: 5px;
        }

        .button {
            width: 100%;
            padding: 12px;
            background-color: #0078D7;
            color: white;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .button:hover {
            background-color: #005a9e;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>User Registration Page</h1>
        <div>
            <p>
                <label for="txtUsername">Enter the Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" />
                <asp:RequiredFieldValidator 
                    ID="user" 
                    runat="server" 
                    ControlToValidate="txtUsername" 
                    ErrorMessage="Username is required" 
                    ForeColor="IndianRed"
                    Display="Dynamic"
                    Style="color:IndianRed; font-size:0.85em; display:block;" />
            </p>
            <p>
                <label for="txtPassword">Enter the Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                <asp:RequiredFieldValidator 
                    ID="password" 
                    runat="server" 
                    ControlToValidate="txtPassword" 
                    ErrorMessage="Password is required" 
                    ForeColor="IndianRed"
                    Display="Dynamic"
                    Style="color:IndianRed; font-size:0.85em; display:block;" />
                <asp:RegularExpressionValidator 
                    ID="passwordRegex" 
                    runat="server" 
                    ControlToValidate="txtPassword"
                    ErrorMessage="Password must be at least 8 characters, include a number and a special character"
                    ValidationExpression="^(?=.*[0-9])(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$"
                    Display="Dynamic"
                    Style="color:IndianRed; font-size:0.85em; display:block;" />
            </p>
            <p>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" OnClick="btnSave_Click" />
            </p>
        </div>
    </form>
</body>
</html>
