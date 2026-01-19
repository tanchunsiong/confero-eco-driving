<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Add_Vehicle_Type.aspx.vb" Inherits="Vehicle_Add_Vehicle_Type" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 <br/>
    <table width="970" align="center">
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblTitle" runat="server" Text="Add Vehicle Type" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblStatus" runat="server" Text="Status: No record added" CssClass="normal_label"></asp:Label><br/>    
                <br />
            </td>
        </tr>   
        <tr>
            <td style="width: 126px" valign="top"> &nbsp;<asp:RequiredFieldValidator ID="vadDescription" runat="server" ControlToValidate="txtDescription"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="lblDescription" runat="server" Text="Description:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtDescription" runat="server" Height="67px" TextMode="MultiLine" MaxLength="45"></asp:TextBox>
            </td>
            
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 126px"> 
                   
            </td>
            <td align="right">
                &nbsp;&nbsp; &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" /></td>    
            <td>
            </td>
        </tr>
  
    </table>
</asp:Content>

