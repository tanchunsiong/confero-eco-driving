<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ManageGallery.aspx.vb" Inherits="web_admin_Setting_ManageGallery" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <br />
    <table align="center" width="970">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblTitle" runat="server" CssClass="title_label" Text="Manage Gallery"></asp:Label><br />
                <br />
            </td>
        </tr>
        <tr valign="top">
            <td style="width: 250px; height: 110px">
                <asp:Panel ID="pnlInfo" runat="server" GroupingText="Information" Height="62px" Width="232px">
                    <table style="width: 219px">
                        <tr>
                            <td style="width: 20px; height: 30px">
                            </td>
                            <td style="height: 30px">
                                <asp:Label ID="lblTotal" runat="server" CssClass="normal_label" Text="Total Record: 0"></asp:Label></td>
                            <td style="height: 30px">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td style="width: 15px; height: 110px">
                &nbsp;</td>
            <td style="height: 110px">
                <asp:Panel ID="pnlImage" runat="server" GroupingText="Upload Image" Height="145px"
                    Width="628px">
                    <table>
                        <tr>
                            <td style="width: 19px; height: 65px">
                            </td>
                            <td style="width: 98px; height: 65px">
                                <asp:Label ID="Label1" runat="server" CssClass="normal_label" Font-Underline="False"
                                    Text="For Image:"></asp:Label></td>
                            <td style="height: 65px">
                                &nbsp;<asp:FileUpload ID="browseFile" runat="server" /></td>
                            <td style="width: 109px; height: 65px">
                                &nbsp;<asp:Button ID="btnFile" runat="server" Text="Upload" Width="81px" /></td>
                        </tr>
                        <tr>
                            <td style="width: 19px; height: 30px">
                            </td>
                            <td colspan="3" style="height: 30px">
                                <asp:Label ID="lblStatus" runat="server" CssClass="normal_label" Text="Status: No file loaded"></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table align="center" width="970">
        <tr>
            <td style="width: 49px">
                <asp:Label ID="lblView" runat="server" CssClass="normal_label" Text="View record by:"
                    Width="130px"></asp:Label>
            </td>
            <td style="width: 37px" valign="bottom">
                <asp:DropDownList ID="lstNoRec" runat="server" AutoPostBack="true" Height="28px"
                    OnSelectedIndexChanged="changeRec" Width="48px">
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 933px">
                </td>
        </tr>
        <tr>
        </tr>
        <tr>
            <td colspan="5">
                <asp:DataGrid ID="grdData" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="dataGrid" ForeColor="#333333" GridLines="None" OnPageIndexChanged="myDataGrid_PageChanger"
                    PagerStyle-Font-Bold="True" PagerStyle-Mode="NextPrev" PagerStyle-NextPageText="Next ->"
                    PagerStyle-PrevPageText="<- Previous" Width="331px" PageSize="5">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditItemStyle BackColor="#2461BF" />
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle Font-Bold="True" Mode="NumericPages" NextPageText="Next -&gt;" PrevPageText="&lt;- Previous" Position="TopAndBottom" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundColumn DataField="galleryID" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="url" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="counter" HeaderText="No"></asp:BoundColumn>
                         <asp:TemplateColumn HeaderText="Image">
                                    <ItemTemplate>
                                        <asp:Image ID="photo" 
                                        Width="150" Height="125" 
                                        Runat="server" />
                                    </ItemTemplate>
                         </asp:TemplateColumn>   
                        <asp:ButtonColumn ButtonType="PushButton" CommandName="delete" Text="Delete"></asp:ButtonColumn>
                    </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
