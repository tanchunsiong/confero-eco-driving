<%@ Page Language="VB" AutoEventWireup="false" CodeFile="View_Tyre.aspx.vb" Inherits="Tyre_View_Tyre" MasterPageFile="~/MasterPage2.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<br/>
    <table width="970" align="center">
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblTitle" runat="server" Text="View Tyre" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr valign="top">
            <td style="height: 110px; width: 250px;"> 
                <asp:Panel ID="pnlInfo" runat="server" Height="62px" Width="232px" GroupingText="Information">
                    <table style="width: 219px">
                        <tr>
                            <td style="width: 20px; height: 30px">
                            </td>
                            <td style="height: 30px">
                                <asp:Label ID="lblTotal" runat="server" CssClass="normal_label" Text="Total Record: 0"></asp:Label></td>
                            <td style="height: 30px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20px; height: 30px;">
                            </td>
                            <td style="height: 30px">
                                <asp:Label ID="lblSearch" runat="server" CssClass="normal_label" Text="Search Record: 0"></asp:Label></td>
                            <td style="height: 30px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td style="height: 110px; width: 15px;">
                <asp:Panel ID="pnlSearch" runat="server" Height="62px" Width="511px" GroupingText="Search Information">
                    <table>
                        <tr>
                            <td style="width: 19px; height: 32px">
                            </td>
                            <td style="height: 32px; width: 91px;">
                                <asp:Label ID="lblSearchBy" runat="server" CssClass="normal_label" Text="Search By:"></asp:Label></td>
                            <td style="height: 32px; width: 130px;">
                                <asp:DropDownList ID="lstSelect" runat="server" Width="130px">
                                    <asp:ListItem Value="tblVehicle.model">Car Model</asp:ListItem>
                                    <asp:ListItem Value="tblVehicle.make">Car Make</asp:ListItem>
                                    <asp:ListItem Value="tblTyre.model">Tyre Model</asp:ListItem>
                                    <asp:ListItem Value="tblTyre.brand">Brand</asp:ListItem>
                                    <asp:ListItem Value="tblTyre.material">Material</asp:ListItem>
                                    <asp:ListItem Value="tblTyre.type">Tyre Type</asp:ListItem>
                                    <asp:ListItem Value="tblTyre.tyreSize">Tyre Size</asp:ListItem>
                                    <asp:ListItem Value="tblTyre.width">Width</asp:ListItem>
                                    <asp:ListItem value="tblTyre.rollingresistance">Rolling Resistance</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="height: 32px">
                                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                            </td>
                            <td style="height: 32px">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" />
                            </td>
                        
                        </tr>

                    </table>
                </asp:Panel>
            </td>
            <td style="height: 110px">
                &nbsp;</td>
        </tr>
      </table>
      
        <table width="970" align="center">
        <tr>
            <td style="width: 49px"> 
                <asp:Label ID="lblView" runat="server" CssClass="normal_label" Text="View record by:" Width="130px"></asp:Label>
                </td>
            <td style="width: 37px" valign="bottom">
                <asp:DropDownList ID="lstNoRec" runat="server" Height="28px" Width="48px" OnSelectedIndexChanged="changeRec"  AutoPostBack="true">
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 933px">
                <asp:Button ID="btnView" runat="server" Text="View All" Width="74px" />
                <asp:Button ID="btnExport" runat="server" Text="Export Data" Width="80px" /></td>
        </tr>
        <tr>
        <tr>
            <td colspan="5">
                   <asp:DataGrid ID="grdData" runat="server" AutoGenerateColumns="False"
                   AllowPaging="True"
                   OnPageIndexChanged="myDataGrid_PageChanger"
                   PagerStyle-Mode="NextPrev"
                   PagerStyle-NextPageText="Next -&gt;"
                   PagerStyle-PrevPageText="&lt;- Previous"
                   PagerStyle-Font-Bold="True" CellPadding="4" ForeColor="#333333" 
                   GridLines="None" CssClass="dataGrid" Width="946px">
         
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditItemStyle BackColor="#2461BF" />
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle NextPageText="Next -&gt;" PrevPageText="&lt;- Previous" Font-Bold="True" Mode="NumericPages"></PagerStyle>
                    <AlternatingItemStyle BackColor="White" />
                    <ItemStyle BackColor="#EFF3FB" />
                                   
                    <Columns>                     
                        <asp:BoundColumn DataField="TyreID" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Counter" HeaderText="No"></asp:BoundColumn>  
                        <asp:BoundColumn DataField="CarModel" HeaderText="Car Model"></asp:BoundColumn>  
                        <asp:BoundColumn DataField="CarMake" HeaderText="Car Make"></asp:BoundColumn>  
                        <asp:BoundColumn DataField="Model" HeaderText="Tyre Model"></asp:BoundColumn>  
                        <asp:BoundColumn DataField="Brand" HeaderText="Brand"></asp:BoundColumn> 
                        <asp:BoundColumn DataField="Material" HeaderText="Material"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Type" HeaderText="Tyre Type"></asp:BoundColumn>
                        <asp:BoundColumn DataField="TyreSize" HeaderText="Tyre Size"></asp:BoundColumn>       
                        <asp:BoundColumn DataField="Width" HeaderText="Width"></asp:BoundColumn>             
                        <asp:BoundColumn DataField="RollingResistance" HeaderText="Rolling Resistance"></asp:BoundColumn>                   
                        <asp:ButtonColumn ButtonType="PushButton" Text="Edit" CommandName="update"></asp:ButtonColumn>
                        <%--<asp:ButtonColumn ButtonType="PushButton" Text="Delete" CommandName="delete"></asp:ButtonColumn>--%>
                    </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:DataGrid> 
            </td>
        </tr>
  
    </table>
</asp:Content>
