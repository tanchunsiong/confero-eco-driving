<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="login" %>

<%@ Register Assembly="NatsNet.Web.UI.Controls" Namespace="NatsNet.Web.UI.Controls"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Confero - Environment Solution</title>

</head>

<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <table align="center">
            <tr>
                <td rowspan="5" style="width: 184px">
                    <asp:Image ID="ImgLogo" runat="server" ImageUrl="~/Image/Logo.png" /></td>
                <td rowspan="1" style="width: 23px; height: 32px">
                </td>
                <td style="width: 6px; height: 32px">
                </td>
                <td colspan="3" style="height: 32px">
                    &nbsp;<asp:Label ID="lblStatus" runat="server" CssClass="normal_label" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td rowspan="5" style="width: 23px">
                </td>
                <td style="width: 6px; height: 17px">
                    <asp:Label ID="lblErrorName" runat="server" ForeColor="Red"></asp:Label></td>
                <td style="height: 17px; width: 112px;">
                    &nbsp;<asp:Label ID="lblUsername" runat="server" Text="User Name:" CssClass="normal_label"></asp:Label></td>
                <td style="width: 171px; height: 17px">
                 
                    <asp:TextBox ID="txtLoginID" runat="server" Width="172px" TabIndex="1" MaxLength="40"></asp:TextBox>
                </td>
                <td style="height: 17px" align="left">
                    </td>
            </tr>
            <tr>
                <td style="width: 6px; height: 28px;">
                    <asp:Label ID="lblErrorPwd" runat="server" ForeColor="Red"></asp:Label></td>
                <td style="width: 112px; height: 28px;"  >
                    &nbsp;<asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="normal_label"></asp:Label></td>
                <td style="width: 171px; height: 28px;" >
                  
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="172px" TabIndex="2" MaxLength="40"></asp:TextBox>
                </td>
                <td align="left" style="height: 28px">
                    </td>
            </tr>
            
            <tr>
                <td style="width: 6px; height: 32px">
                    <asp:Label ID="lblErrorVerify" runat="server" ForeColor="Red"></asp:Label></td>
                <td style="width: 112px; height: 32px;" >
                    &nbsp;<asp:Label ID="lblImage" runat="server" CssClass="normal_label" Text="Image Verify:"></asp:Label></td>
                <td style="height: 32px; width: 171px;">
                    <asp:TextBox ID="txtImgVerifyCode" runat="server" Width="172px" TabIndex="3" MaxLength="40"></asp:TextBox></td>
                <td>
                    <cc1:ImageVerifier ID="ImageVerifier1" runat="server" /></td>
            </tr>
            
            <tr>
                <td style="width: 6px; height: 33px">
                </td>
            <td style="height: 33px; width: 112px;">
                &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="registerUser.aspx">Register Account</asp:HyperLink></td>
            <td align="right">
                &nbsp;&nbsp;
                <asp:Button ID="btnLogin" runat="server" Text="Login" TabIndex="4" /></td>
            <td style="height: 33px" align="left">
                   </td>
            </tr>
            
        </table>

    </form>
</body>
</html>
