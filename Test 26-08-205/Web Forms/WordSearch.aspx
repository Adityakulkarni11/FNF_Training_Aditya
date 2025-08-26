<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WordSearch.aspx.cs" Inherits="SearchWord.WordSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Search Word</h2>
        <div>    
        <p>
            English Word: <asp:TextBox ID="txtSearchWord" runat="server" />
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </p>
        
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

        </div>
    </form>
</body>
</html>
