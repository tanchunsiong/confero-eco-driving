<%@ Page Language="VB" AutoEventWireup="false" CodeFile="health.aspx.vb" Inherits="Web_Admin_health" MasterPageFile="~/MasterAdmin.master" %>

    <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <br />
        <table style="width: 100%">
            <tr>
                <td style="width: 20px">
                </td>
                <td colspan="5">
                    <strong>Failure History</strong></td>
            </tr>
            <tr>
                <td style="width: 20px">
                </td>
                <td colspan="5">
                    <asp:DataGrid ID="DataGrid1" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                        Font-Size="Smaller" PageSize="10" Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="reportingID" HeaderText="ID"></asp:BoundColumn>
                            <asp:BoundColumn DataField="datetimeOfFailure" HeaderText="Date of Failure"></asp:BoundColumn>
                            <asp:BoundColumn DataField="recipientOfReport" HeaderText="Report Recipient"></asp:BoundColumn>
                            <asp:BoundColumn DataField="reasonForReport" HeaderText="Reason for failure"></asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                    <asp:Label ID="lblDataGird" runat="server"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td style="width: 20px; height: 320px">
                </td>
                <td colspan="5" style="height: 320px">
                    <asp:Panel ID="pnlSearch" runat="server" GroupingText="Reporting Number" Height="299px"
                        Width="511px">
                        <table>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                </td>
                                <td colspan="4" style="height: 32px">
                                    This Month: &nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                </td>
                                <td colspan="4" style="height: 32px">
                    Current reports are sent to mobile number :
                    <asp:Label ID="lblMobile" runat="server"></asp:Label><br />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TextBox1"></asp:RequiredFieldValidator></td>
                                <td colspan="4" style="height: 32px">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Change number" Width="112px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                </td>
                                <td colspan="4" style="height: 32px">
                    <asp:Label ID="lblNotice" runat="server" ForeColor="Red"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                </td>
                                <td colspan="4" style="height: 32px">
                    For the mobile number, please ensure that the format is in international format.<br />
                                    <br />
                    Example if the number is +65 94564655, please enter 6594564655</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 20px">
                </td>
                <td colspan="5">
                </td>
            </tr>
        </table>
  <br/>
    </asp:Content>

