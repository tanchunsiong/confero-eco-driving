<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Change_Password.aspx.vb" Inherits="User_Change_Password" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
<br/>
    <table width="970" align="center">
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblTitle" runat="server" Text="Change Password" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblStatus" runat="server" Text="Status: No change" CssClass="normal_label"></asp:Label><br/>    
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;<asp:RequiredFieldValidator ID="vadUser" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblUsername" runat="server" Text="User Name:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtUsername" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td style="height: 30px">
                </td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;<asp:RequiredFieldValidator ID="vadPwd" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="149px" MaxLength="45"></asp:TextBox><ajaxToolkit:PasswordStrength ID="PasswordStrength1" runat="server" DisplayPosition="RightSide"
                    HelpStatusLabelID="TextBox1_HelpLabel" PreferredPasswordLength="10" PrefixText="Strength:"
                    StrengthIndicatorType="Text" TargetControlID="txtPassword" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent">
                </ajaxToolkit:PasswordStrength>
            </td>
            
            <td style="height: 30px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Password must have a minimum length of 8 characters." ValidationExpression="^.{8,40}$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;<asp:RequiredFieldValidator ID="vadCPwd" runat="server" ControlToValidate="txtCPassword"
                    ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator>
                <asp:Label ID="lblCPassword" runat="server" Text="Confirm Password:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtCPassword" runat="server" TextMode="Password" Width="148px" MaxLength="45"></asp:TextBox>
            </td>
            
            <td style="height: 30px">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                    ControlToValidate="txtCPassword" ErrorMessage="Mismatch Password"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 178px"> 
                   
            </td>
            <td align="right">
                &nbsp;&nbsp; &nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" /></td>    
            <td>
            </td>
        </tr>
  
    </table>
</asp:Content>

