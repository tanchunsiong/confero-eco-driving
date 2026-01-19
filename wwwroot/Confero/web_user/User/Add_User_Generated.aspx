<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Add_User_Generated.aspx.vb" Inherits="User_Add_User_Generated" MasterPageFile="~/MasterPage2.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<br/>
    <table width="970" align="center">
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblTitle" runat="server" Text="Add User Generated Info" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblStatus" runat="server" Text="Status: No record added" CssClass="normal_label"></asp:Label><br/>    
                <br />
            </td>
        </tr>   
        <tr>
            <td style="width: 126px; height: 68px;" valign="top"> <asp:RequiredFieldValidator ID="vadDescription" runat="server" ControlToValidate="txtDescription"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblDescription" runat="server" Text="Description:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 168px; height: 68px;">
                <asp:TextBox ID="txtDescription" runat="server" Height="67px" TextMode="MultiLine" MaxLength="45"></asp:TextBox>
            </td>
            
            <td style="height: 68px">
            </td>
        </tr>
        <tr>
            <td style="width: 126px; height: 30px;"> 
                <asp:RequiredFieldValidator ID="vadValue" runat="server" ControlToValidate="txtValue"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblValue" runat="server" CssClass="normal_label" Text="Value:"></asp:Label></td>
            <td style="width: 168px; height: 30px;">
                <asp:TextBox ID="txtValue" runat="server" Width="175px" MaxLength="45"></asp:TextBox>
            </td>    
            <td style="height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 126px; height: 30px">
            </td>
            <td style="width: 168px; height: 30px">
            </td>
            <td style="height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 126px; height: 30px">
            </td>
            <td style="width: 168px; height: 30px">
            </td>
            <td style="height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 126px; height: 30px">
            </td>
            <td style="width: 168px; height: 30px">
            </td>
            <td style="height: 30px">
            </td>
        </tr>
         <tr>
            <td style="width: 126px"> 
               
            <td  align="right">
                <asp:Button ID="btnAdd" runat="server" Text="Add" /></td>    
            <td>
            </td>
        </tr>
  
    </table>
</asp:Content>

