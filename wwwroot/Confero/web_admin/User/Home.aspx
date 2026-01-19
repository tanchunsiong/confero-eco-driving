<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Home" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<br/>
    <table width="970" align="center">
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblTitle" runat="server" Text="Summary" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr>
            <td style="width: 17px; height: 33px;"> &nbsp;&nbsp;
            </td>
            <td style="width: 335px; height: 33px;">
                <asp:Label ID="lblPropellent" runat="server" CssClass="normal_label" Text=""></asp:Label></td>
            <td style="height: 33px">
                &nbsp;<asp:Label ID="lblUserGenerate" runat="server" CssClass="normal_label" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 17px; height: 33px;"> &nbsp;&nbsp;
            </td>
            <td style="width: 335px; height: 33px;">
                <asp:Label ID="lblPropellentType" runat="server" CssClass="normal_label" Text=""></asp:Label></td>
            <td style="height: 33px">
                &nbsp;<asp:Label ID="lblVehicle" runat="server" CssClass="normal_label" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 17px; height: 32px;"> &nbsp;
            </td>
            <td style="width: 335px; height: 32px;">
                <asp:Label ID="lblTrip" runat="server" CssClass="normal_label" Text=""></asp:Label>&nbsp;</td>
            
            <td style="height: 32px">
                &nbsp;<asp:Label ID="lblConfiguration" runat="server" CssClass="normal_label" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 17px; height: 34px;"> &nbsp;
            </td>
            <td style="width: 335px; height: 34px;">
                <asp:Label ID="lblTyre" runat="server" CssClass="normal_label" Text=""></asp:Label></td>
            
            <td style="height: 34px">
                &nbsp;<asp:Label ID="lblOwnership" runat="server" CssClass="normal_label" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 17px; height: 32px;"> &nbsp;
            </td>
            <td style="width: 335px; height: 32px;">
                <asp:Label ID="lblUser" runat="server" CssClass="normal_label" Text=""></asp:Label></td>
            
            <td style="height: 32px">
                &nbsp;<asp:Label ID="lblType" runat="server" CssClass="normal_label" Text=""></asp:Label></td>
        </tr>
    </table>
</asp:Content>
