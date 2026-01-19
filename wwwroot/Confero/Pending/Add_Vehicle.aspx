<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Add_Vehicle.aspx.vb" Inherits="Vehicle_Add_Vehicle" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<br/>
    <table width="970" align="center">
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblTitle" runat="server" Text="Add Vehicle" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblStatus" runat="server" Text="Status: No record added" CssClass="normal_label"></asp:Label><br/>    
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 160px"> &nbsp;<asp:RequiredFieldValidator ID="vadType" runat="server" ErrorMessage="*" ControlToValidate="lstVehicleType"></asp:RequiredFieldValidator>
                <asp:Label ID="lblVehicleType" runat="server" Text="Vehicle Type:" CssClass="normal_label"></asp:Label>    
            </td>
            <td style="width: 82px">
                <asp:DropDownList ID="lstVehicleType" runat="server" Width="156px">
                </asp:DropDownList>
            </td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 160px"> &nbsp;<asp:RequiredFieldValidator ID="vadModel" runat="server" ErrorMessage="*" ControlToValidate="txtModel"></asp:RequiredFieldValidator>
                <asp:Label ID="lblModel" runat="server" Text="Model:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
            </td>
            
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 160px"> &nbsp;<asp:RequiredFieldValidator ID="vadMake" runat="server" ErrorMessage="*" ControlToValidate="txtMake"></asp:RequiredFieldValidator>
                <asp:Label ID="lblMake" runat="server" Text="Make:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtMake" runat="server"></asp:TextBox>
            </td>
            
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 160px"> &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtYears"></asp:RequiredFieldValidator>
                <asp:Label ID="lblYears" runat="server" Text="Years:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtYears" runat="server"></asp:TextBox>
            </td>
            
            <td>
                </td>
        </tr>
          <tr>
            <td style="width: 160px"> &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtCapacity"></asp:RequiredFieldValidator>
                <asp:Label ID="lblCapacity" runat="server" Text="Capacity:" CssClass="normal_label"></asp:Label></td>
            <td style="width: 82px">
                <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
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
