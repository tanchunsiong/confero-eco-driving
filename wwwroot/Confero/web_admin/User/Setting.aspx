<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Setting.aspx.vb" Inherits="web_admin_User_Setting" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 <br/>
    <table width="970" align="center">
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblTitle" runat="server" Text="Update Login Setting" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblStatus" runat="server" Text="Status: No record updated" CssClass="normal_label"></asp:Label><br/>    
                <br />
            </td>
        </tr>   
        <tr>
            <td style="width: 212px; height: 21px;" valign="top"> &nbsp;<asp:RequiredFieldValidator ID="vadTimout" runat="server" ControlToValidate="txtTimeout"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblTimeout" runat="server" Text="Login Timout:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 79px; height: 21px;">
                <asp:TextBox ID="txtTimeout" runat="server" Width="90px"></asp:TextBox></td>
            
            <td style="height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 212px; height: 21px;" valign="top"> &nbsp;<asp:RequiredFieldValidator ID="vadAttempts" runat="server" ControlToValidate="txtAttempts"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblAttempts" runat="server" Text="Number of Attempts:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 79px; height: 21px;">
                <asp:TextBox ID="txtAttempts" runat="server" Width="90px"></asp:TextBox></td>
            
            <td style="height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 212px"> 
                   
            </td>
            <td align="right" >
               <asp:Button ID="btnUpdate" runat="server" Text="Update" /></td>    
            <td>
            </td>
        </tr>
  
    </table>
</asp:Content>
