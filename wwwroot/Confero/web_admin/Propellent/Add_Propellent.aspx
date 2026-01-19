<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Add_Propellent.aspx.vb" Inherits="Propellent_Add_Propellent"  MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <br/>
    <table width="970" align="center">
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblTitle" runat="server" Text="Add Propellent" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblStatus" runat="server" Text="Status: No record added" CssClass="normal_label"></asp:Label><br/>    
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 160px"> &nbsp;<asp:RequiredFieldValidator ID="vadType" runat="server" ErrorMessage="*" ControlToValidate="lstPropellentType"></asp:RequiredFieldValidator>
                <asp:Label ID="lblPropellentType" runat="server" Text="Propellent Type:" CssClass="normal_label"></asp:Label>    
            </td>
            <td style="width: 82px">
                <asp:DropDownList ID="lstPropellentType" runat="server" Width="156px">
                </asp:DropDownList>
            </td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 160px"> &nbsp;<asp:RequiredFieldValidator ID="vadOctane" runat="server" ErrorMessage="*" ControlToValidate="txtOctane"></asp:RequiredFieldValidator>
                <asp:Label ID="lblOctane" runat="server" Text="Octane:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtOctane" runat="server" MaxLength="45"></asp:TextBox>
            </td>
            
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 160px"> &nbsp;<asp:RequiredFieldValidator ID="vadBrand" runat="server" ErrorMessage="*" ControlToValidate="txtBrand"></asp:RequiredFieldValidator>
                <asp:Label ID="lblBrand" runat="server" Text="Brand:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtBrand" runat="server" MaxLength="45"></asp:TextBox>
            </td>
            
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 160px"> 
                   
            </td>
            <td align="right">
                &nbsp;&nbsp; &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" /></td>    
            <td>
            </td>
        </tr>
  
    </table>
</asp:Content>
