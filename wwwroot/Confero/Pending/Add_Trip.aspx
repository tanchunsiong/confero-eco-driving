<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Add_Trip.aspx.vb" Inherits="Trip_Add_Trip" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
 <br/>
    <table width="970" align="center">
        <tr>
            <td colspan="5"> 
                <asp:Label ID="lblTitle" runat="server" Text="Add Trip" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr>
            <td colspan="5"> 
                <asp:Label ID="lblStatus" runat="server" Text="Status: No record added" CssClass="normal_label"></asp:Label><br/>    
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 186px; height: 30px;"> 
                <asp:Label ID="lblVehicleConfig" runat="server" Text="Vehicle Configuration:" CssClass="normal_label"></asp:Label>    
            </td>
            <td style="width: 82px; height: 30px;">
                <asp:DropDownList ID="lstVehicleConfig" runat="server" Width="156px">
                </asp:DropDownList>
            </td>
            <td style="height: 30px; width: 75px;">
            </td>
            
            <td style="width: 107px; height: 30px;">
                <asp:Label ID="lblStart" runat="server" CssClass="normal_label" Text="Start Time:"></asp:Label></td>
            <td style="width: 153px; height: 30px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 186px; height: 30px;"> 
                <asp:Label ID="lblSpeed" runat="server" Text="Optimum Speed:" CssClass="normal_label"></asp:Label>    
            </td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtSpeed" runat="server"></asp:TextBox>
            </td>
            
            <td style="width: 75px; height: 30px;">
            </td>
             <td style="width: 107px; height: 30px;">
                 <asp:Label ID="lblEnd" runat="server" CssClass="normal_label" Text="End Time:"></asp:Label></td>
            <td style="width: 153px; height: 30px">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 186px; height: 30px;"> 
                <asp:Label ID="lblWeight" runat="server" Text="Weight of Vehicle:" CssClass="normal_label"></asp:Label>    
            </td>
            <td style="width: 82px; height: 30px;">
                <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
            </td>
            
            <td style="width: 75px; height: 30px;">
            </td>
            <td style="width: 107px; height: 30px;">
                <asp:Label ID="lblFuel" runat="server" CssClass="normal_label" Text="Fuel Usage:"></asp:Label></td>
            <td style="width: 153px; height: 30px">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 186px; height: 30px;"> 
                <asp:Label ID="lblLocation" runat="server" CssClass="normal_label" Text="Location:"></asp:Label></td>
            <td style="height: 30px" >
                <asp:TextBox id="txtLocation" runat="server"></asp:TextBox>
            </td>    
            <td style="width: 75px; height: 30px;">
            </td>
            <td style="width: 107px; height: 30px;">
                <asp:Label ID="lblGForce" runat="server" CssClass="normal_label" Text="Max GForce:"></asp:Label></td>
            <td style="width: 153px; height: 30px">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 186px; height: 30px;"> 
                <asp:Label ID="lblWeather" runat="server" CssClass="normal_label" Text="Weather Condition:"></asp:Label></td>
            <td style="height: 30px" >
                <asp:TextBox id="txtWeather" runat="server"></asp:TextBox>
            </td>    
            <td style="width: 75px; height: 30px;">
            </td>
            <td style="width: 107px; height: 30px;">
                <asp:Label ID="lblHorsepower" runat="server" CssClass="normal_label" Text="Horsepower:"></asp:Label></td>
            <td style="width: 153px; height: 30px">
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 186px"> 
                <asp:Label ID="lblDistance" runat="server" CssClass="normal_label" Text="Distance Travelled:"></asp:Label></td>
            <td >
                <asp:TextBox id="txtDistance" runat="server"></asp:TextBox>
            </td>    
            <td style="width: 75px">
            </td>
            <td style="width: 107px">
            </td>
            <td style="width: 153px" align="right">
                &nbsp;
                <asp:Button ID="btnAdd" runat="server" Text="Add" /></td>
        </tr>
        <tr>
            <td style="width: 186px">              
            <td >

            </td>    
            <td style="width: 75px">
            </td>
            <td style="width: 107px">
            </td>
            <td style="width: 153px">
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

