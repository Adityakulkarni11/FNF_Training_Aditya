<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="LoginTask.UserList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User List</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f0f2f5;
            margin: 0;
            padding: 0;
        }

        form {
            width: 90%;
            max-width: 800px;
            margin: 50px auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.1);
        }

        .card {
            background-color: #fafafa;
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 15px;
            margin-bottom: 15px;
            box-shadow: 0 2px 5px rgba(0,0,0,0.05);
        }

        .card h3 {
            margin: 0 0 10px;
            color: #333;
        }

        .card a, .card asp\:LinkButton {
            color: #0078D7;
            text-decoration: none;
            font-weight: bold;
        }

        .card a:hover, .card asp\:LinkButton:hover {
            text-decoration: underline;
        }

        .details-view {
            margin-top: 30px;
            border-collapse: collapse;
            width: 100%;
        }

        .details-view th, .details-view td {
            padding: 10px;
            border: 1px solid #ccc;
        }

        .details-view th {
            background-color: #f4f4f4;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="rptUsers" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <h3><%# Eval("Username") %></h3>
                        <asp:LinkButton ID="lnkDetails" runat="server" CommandArgument='<%# Eval("Id") %>' OnCommand="ShowDetails">View Details</asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <asp:DetailsView ID="dvUserDetails" runat="server" AutoGenerateRows="False" Visible="false" CssClass="details-view">
                <Fields>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                </Fields>
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>
