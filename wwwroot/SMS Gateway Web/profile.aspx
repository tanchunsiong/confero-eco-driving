<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="profile.aspx.vb" Inherits="SMSGatewayWS.profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            height: 36px;
        }
        .style2
        {
            height: 96px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table border="1" style="width:100%;">
            <tr bgcolor="#FFCC00">
                <td class="style2" colspan="3" align=right>
                   <b> Balance : </b>                    <asp:Label ID="lblSMSLeft" runat="server"></asp:Label>
                   &nbsp;<b>Username : </b><asp:Label ID="lblUserName" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr bgcolor="Silver">
                <td class="style18">
                  <a href=user.aspx> <b>Central Home</b></a></td>
                <td>
                    <a href=applications.aspx><b>My applications</b></a></td>
                <td class="style9">
                   <a href=report.aspx><b> Message Report</b></a></td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
