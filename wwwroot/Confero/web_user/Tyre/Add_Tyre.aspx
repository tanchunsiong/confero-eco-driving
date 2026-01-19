<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Add_Tyre.aspx.vb" Inherits="Tyre_Add_Tyre" MasterPageFile="~/MasterPage2.master" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<br/><ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</ajaxToolkit:ToolkitScriptManager>
    <table width="970" align="center">
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblTitle" runat="server" Text="Add Tyre" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblStatus" runat="server" Text="Status: No record added" CssClass="normal_label"></asp:Label><br/>    
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 186px">
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtModel"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="Label4" runat="server" CssClass="normal_label" Text="Car Model:"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtCarModel" runat="server" MaxLength="45" Enabled="False"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 186px">
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtModel"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="Label3" runat="server" CssClass="normal_label" Text="Car Make:"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtCarMake" runat="server" Enabled="False" MaxLength="45"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 186px">
                &nbsp;<asp:RequiredFieldValidator ID="vadModel" runat="server" ControlToValidate="txtModel"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="Label1" runat="server" CssClass="normal_label" Text="Model:"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtModel" runat="server" MaxLength="45"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 186px"> &nbsp;<asp:RequiredFieldValidator ID="vadBrand" runat="server" ErrorMessage="*" ControlToValidate="txtBrand"></asp:RequiredFieldValidator>
                <asp:Label ID="lblBrand" runat="server" Text="Brand:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtBrand" runat="server" MaxLength="45"></asp:TextBox>&nbsp;</td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 186px"> &nbsp;<asp:RequiredFieldValidator ID="vadWidth" runat="server" ErrorMessage="*" ControlToValidate="txtWidth"></asp:RequiredFieldValidator>
                <asp:Label ID="lblWidth" runat="server" Text="Width:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtWidth" runat="server" MaxLength="45"></asp:TextBox>
            </td>
            
            <td>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                    FilterType="Numbers" TargetControlID="txtWidth">
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 186px">
                &nbsp;<asp:RequiredFieldValidator ID="vadType" runat="server" ControlToValidate="txtType"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:Label ID="Label2" runat="server" CssClass="normal_label" Text="Tyre Type:"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtType" runat="server" MaxLength="14"></asp:TextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 186px"> &nbsp;<asp:RequiredFieldValidator ID="vadTyre" runat="server" ErrorMessage="*" ControlToValidate="txtTyre"></asp:RequiredFieldValidator>
                <asp:Label ID="lblTyre" runat="server" CssClass="normal_label" Text="Tyre Size:"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtTyre" runat="server" MaxLength="45"></asp:TextBox>
            </td>
            
            <td>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                    FilterType="Numbers" TargetControlID="txtTyre">
                </ajaxToolkit:FilteredTextBoxExtender>
            </td>
        </tr>
         <tr>
            <td style="width: 186px; height: 26px;"> &nbsp;<asp:RequiredFieldValidator ID="vadMaterial" runat="server" ErrorMessage="*" ControlToValidate="txtMaterial"></asp:RequiredFieldValidator>
                <asp:Label ID="lblMaterial" runat="server" CssClass="normal_label" Text="Material:"></asp:Label></td>
            <td style="width: 82px; height: 26px;">
                <asp:TextBox ID="txtMaterial" runat="server" MaxLength="45"></asp:TextBox>
            </td>
            
            <td style="height: 26px">
                </td>
        </tr>
        <tr>
            <td style="width: 186px"> &nbsp;<asp:RequiredFieldValidator ID="vadResistance" runat="server" ErrorMessage="*" ControlToValidate="txtResistance"></asp:RequiredFieldValidator>
                <asp:Label ID="lblResistance" runat="server" CssClass="normal_label" Text="Rolling Resistance:"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtResistance" runat="server" MaxLength="45"></asp:TextBox>
            </td>
            
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 186px"> 
                   
            </td>
            <td align="right">
                &nbsp;&nbsp; &nbsp;<asp:Button ID="btnAdd" runat="server" Text="Add" /></td>    
            <td>
            </td>
        </tr>
  
    </table>
</asp:Content>
