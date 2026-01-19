<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Add_User.aspx.vb" Inherits="User_Add_User" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
 <br/>
    <table width="970" align="center">
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblTitle" runat="server" Text="Add User Account" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 58px"> 
                <asp:Label ID="lblStatus" runat="server" Text="Status: No record added" CssClass="normal_label"></asp:Label><br/>    
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;<asp:RequiredFieldValidator ID="vadName" runat="server" ControlToValidate="txtName"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblName" runat="server" Text="Name:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtName" runat="server" Width="174px" MaxLength="45"></asp:TextBox></td>
            <td style="height: 30px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Name must include First Name and Last Name, cannot include special characters" ValidationExpression="^([a-zA-Z]+[\'\,\.\-]?[a-zA-Z ]*)+[ ]([a-zA-Z]+[\'\,\.\-]?[a-zA-Z ]+)+$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;<asp:RequiredFieldValidator ID="vadGender" runat="server" ControlToValidate="lstGender"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblGender" runat="server" Text="Gender:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px; height: 30px;">
                <asp:DropDownList ID="lstGender" runat="server" Width="99px">
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="height: 30px">
                </td>
        </tr>
         <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;<asp:RequiredFieldValidator ID="vadDob" runat="server" ControlToValidate="txtDob"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblDOB" runat="server" Text="DOB:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtDob" runat="server" Width="174px" MaxLength="45"></asp:TextBox></td>
            <td style="height: 30px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDob"
                    ErrorMessage="Invalid DOB, Eg: dd/mm/yyyy  " ValidationExpression=" ((([0][1-9]|[12][\d])|[3][01])[-/]([0][13578]|[1][02])[-/][1-9]\d\d\d)|((([0][1-9]|[12][\d])|[3][0])[-/]([0][13456789]|[1][012])[-/][1-9]\d\d\d)|(([0][1-9]|[12][\d])[-/][0][2][-/][1-9]\d([02468][048]|[13579][26]))|(([0][1-9]|[12][0-8])[-/][0][2][-/][1-9]\d\d\d) "></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;<asp:RequiredFieldValidator ID="vadTelephone" runat="server" ControlToValidate="txtTelephone"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblTelephone" runat="server" Text="Telephone:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtTelephone" runat="server" Width="174px" MaxLength="45"></asp:TextBox></td>
            <td style="height: 30px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTelephone"
                    ErrorMessage="Contact Number must be 8 digits" ValidationExpression="^\d{8}$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;<asp:RequiredFieldValidator ID="vadEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblEmail" runat="server" Text="Email:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtEmail" runat="server" Width="174px" MaxLength="45"></asp:TextBox></td>
            <td style="height: 30px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Invalid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;" valign="top"> &nbsp;<asp:RequiredFieldValidator ID="vadAddress" runat="server" ControlToValidate="txtAddress"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblAddress" runat="server" Text="Address:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtAddress" runat="server" Height="87px" TextMode="MultiLine" MaxLength="45"></asp:TextBox></td>
            <td style="height: 30px">
                </td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;
            </td>
            <td style="width: 82px; height: 30px;">
                &nbsp;</td>
            <td style="height: 30px">
                </td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;<asp:RequiredFieldValidator ID="vadRole" runat="server" ControlToValidate="lstGender"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblRole" runat="server" CssClass="normal_label" Text="Role:"></asp:Label></td>
            <td style="width: 82px; height: 30px;"><asp:DropDownList ID="lstRole" runat="server" Width="99px">
                <asp:ListItem Value="admin">Admin</asp:ListItem>
                <asp:ListItem Value="user">User</asp:ListItem>
            </asp:DropDownList></td>
            <td style="height: 30px">
                </td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;<asp:RequiredFieldValidator ID="vadUser" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblUsername" runat="server" Text="User Name:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtUsername" runat="server" Width="173px" MaxLength="45"></asp:TextBox>
            </td>
            <td style="height: 30px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Invalid User Name or minimum 5 character " ValidationExpression="\w{5,255}"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 178px;" valign="top"> &nbsp;<asp:RequiredFieldValidator ID="vadPwd" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblPassword" runat="server" Text="Password:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px;">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="172px" MaxLength="45"></asp:TextBox>
                
                <ajaxToolkit:PasswordStrength ID="PasswordStrength1" runat="server" DisplayPosition="RightSide"
                    HelpStatusLabelID="TextBox1_HelpLabel" PreferredPasswordLength="10" PrefixText="Strength:"
                    StrengthIndicatorType="Text" TargetControlID="txtPassword" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent">
                </ajaxToolkit:PasswordStrength>
                </td>
            
            <td valign="top">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Password must have a minimum length of 8 characters." ValidationExpression="^.{8,40}$"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 178px; height: 30px;"> &nbsp;<asp:RequiredFieldValidator ID="vadCPwd" runat="server" ControlToValidate="txtCPassword"
                    ErrorMessage="*" Width="8px"></asp:RequiredFieldValidator>
                <asp:Label ID="lblCPassword" runat="server" Text="Confirm Password:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtCPassword" runat="server" TextMode="Password" Width="171px" MaxLength="45"></asp:TextBox>
            </td>
            
            <td style="height: 30px">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                    ControlToValidate="txtCPassword" ErrorMessage="Mismatch Password"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 178px"> 
                   
            </td>
            <td align="right">
                &nbsp;&nbsp; &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" /></td>    
            <td>
            </td>
        </tr>
  
    </table>
</asp:Content>
