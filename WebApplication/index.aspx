<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" EnableEventValidation="false" Inherits="WebApplication.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:DropDownList ID="ddl1" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btn1" runat="server" Text="Button" onclick="btn1_Click" 
        style="height: 21px" />
    </form>
    <script type="text/javascript">
        $("#ddl1").html("<option value='1'>123</option>")
    </script>
</body>
</html>
h