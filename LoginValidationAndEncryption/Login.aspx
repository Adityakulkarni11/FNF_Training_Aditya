<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginTask.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f0f2f5;
            margin: 0;
            padding: 0;
        }

        form {
            width: 400px;
            margin: 80px auto;
            padding: 30px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.1);
        }

        h1 {
            text-align: center;
            color: #333;
            margin-bottom: 30px;
        }

        p {
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }

        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .button {
            padding: 10px 20px;
            background-color: #0078D7;
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 14px;
            cursor: pointer;
            margin-top: 10px;
        }

        .button:hover {
            background-color: #005a9e;
        }

        .validator {
            color: IndianRed;
            font-size: 0.85em;
            display: block;
            margin-top: 5px;
        }

        .message {
            margin-top: 15px;
            color: red;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>User Login Page</h1>
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
            </p>
            <p>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" OnClick="btnLogin_Click" />
                &nbsp;&nbsp; New User?
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="button" OnClick="btnRegister_Click" CausesValidation="false" />
            </p>
            <asp:Label ID="lblMessage" runat="server" CssClass="message" />
        </div>
    </form>
</body>
</html>
