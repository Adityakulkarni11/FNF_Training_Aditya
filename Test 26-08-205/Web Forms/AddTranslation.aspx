<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTranslation.aspx.cs" Inherits="SearchWord.AddTranslation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <h2>Add Translation</h2>
        <div>        
            <asp:Label ID="lblWord" runat="server" />
            <asp:TextBox ID="txtTranslation" runat="server" />
            <asp:Button ID="btnAdd" runat="server" Text="Add to My Words" OnClick="btnAdd_Click" />
            <br /><br />
            <asp:GridView ID="Words" runat="server" AutoGenerateColumns="false" >
                <Columns>
                    <asp:BoundField DataField="Word" HeaderText="Word" />
                    <asp:BoundField DataField="Translation" HeaderText="Translation" />
                 </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
