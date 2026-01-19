<%@ Page Language="VB" AutoEventWireup="false" CodeFile="registeruser.aspx.vb" Inherits="registeruser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
        <br />
        <br />
   <table align="center">
            <tr>
                <td class="style1" rowspan="5" style="width: 28px">
                    <asp:Image ID="ImgLogo" runat="server" ImageUrl="~/Image/Logo.png" /></td>
                <td class="style1" rowspan="5" style="width: 19px">
                </td>
                <td class="style1" style="width: 13px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        Width="3px" ControlToValidate="TextBox1"></asp:RequiredFieldValidator></td>
                <td class="style1" style="width: 133px">
                    User Name:</td>
                <td style="width: 143px">
                    <asp:TextBox ID="TextBox1" runat="server" Width="149px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 13px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        Width="3px" ControlToValidate="TextBox2"></asp:RequiredFieldValidator></td>
                <td class="style1" style="width: 133px">
                    Password:</td>
                <td style="width: 143px">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="148px"></asp:TextBox>&nbsp;
                </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td class="style1" style="width: 13px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                        Width="3px" ControlToValidate="TextBox3"></asp:RequiredFieldValidator></td>
                <td class="style1" style="width: 133px">
                    Confirm Password:</td>
                <td style="width: 143px">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Width="148px"></asp:TextBox>&nbsp;
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToCompare="TextBox2" ControlToValidate="TextBox3" 
                        ErrorMessage="Password mismatch"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td class="style1" style="width: 13px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                        Width="3px" ControlToValidate="TextBox4"></asp:RequiredFieldValidator></td>
                <td class="style1" style="width: 133px">
                    Mobile Number:</td>
                <td style="width: 143px">
                    <asp:TextBox ID="TextBox4" runat="server" Width="149px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 13px; height: 26px">
                </td>
                <td class="style1" style="width: 133px; height: 26px">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Login Page</asp:HyperLink></td>
                <td  align="right">
                    &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                </td>
                <td style="height: 26px">
                </td>
            </tr>
       <tr>
           <td class="style1" style="width: 28px">
           </td>
           <td class="style1" style="width: 19px">
           </td>
           <td class="style1" style="width: 13px">
           </td>
           <td class="style1" style="width: 133px">
           </td>
           <td style="width: 143px">
                    <asp:Label ID="lblNotice" runat="server"></asp:Label></td>
           <td>
           </td>
       </tr>
        </table>
    </form>
</body>
</html>
