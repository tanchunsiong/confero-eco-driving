<%@ Page Language="VB" AutoEventWireup="false" CodeFile="admin.aspx.vb" Inherits="Web_Admin_admin" MasterPageFile="~/MasterAdmin.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <br/>
        <table style="width: 100%;">
            <tr>
                <td style="width: 20px"></td>
                <td colspan="5">
                    <asp:Panel ID="pnlSearch" runat="server" GroupingText="Message Summary" 
                        Width="511px" Height="299px">
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
                                    <asp:Label ID="lblSentMessages" runat="server"></asp:Label>
                                    &nbsp;messages sent with acknowledgement<br />
                                    <asp:Label ID="lblSentMessages2" runat="server"></asp:Label>
                                    &nbsp;messages sent without acknowledgement<br />
                                    <br />
                                    <asp:Label ID="lblReceivedMessages" runat="server"></asp:Label>
                                    &nbsp;messages received
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                </td>
                                <td colspan="4" style="height: 32px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                </td>
                                <td colspan="4" style="height: 32px">
                    To Date :<br />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                </td>
                                <td colspan="4" style="height: 32px">
                                    <asp:Label ID="lblTotalSentMessages" runat="server"></asp:Label>
                                    &nbsp;messages sent with acknowledgement<br />
                                    <asp:Label ID="lblTotalSentMessages2" runat="server"></asp:Label>
                                    messages sent without acknowledgement<br />
                                    <asp:Label ID="lblTotalReceivedMessages" runat="server"></asp:Label>
                &nbsp;messages received</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 20px"></td>
                <td colspan="5">
                    <asp:Panel ID="Panel1" runat="server" GroupingText="Benchmark" Width="511px" Height="139px">
                        <table>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                </td>
                                <td colspan="4" style="height: 32px">
                                    Maximum SMS Per Minute Throughput to date :</td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                </td>
                                <td colspan="4" style="height: 32px">
                                    <asp:Label ID="lblThruput" runat="server"></asp:Label>
                                    messages</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 20px"></td>
                <td colspan="5">
                    <asp:Panel ID="Panel2" runat="server" GroupingText="Send SMS" Width="511px" Height="312px">
                        <table>
                            <tr>
                                <td style="width: 19px; height: 32px" valign="top">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtDestination"></asp:RequiredFieldValidator></td>
                                <td colspan="4" style="height: 32px">
                    Destination Number<br />
                                </td>
                                <td colspan="1" style="width: 86px; height: 32px">
                    <asp:TextBox ID="txtDestination" runat="server" Width="175px"></asp:TextBox><br />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 32px" valign="top">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtMessage"></asp:RequiredFieldValidator></td>
                                <td colspan="4" style="height: 32px" valign="top">
                                    Message</td>
                                <td colspan="1" style="width: 86px; height: 32px">
                    <asp:TextBox ID="txtMessage" runat="server" Height="134px" TextMode="MultiLine" 
                        Width="171px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                </td>
                                <td colspan="4" style="height: 32px" valign="top">
                                </td>
                                <td colspan="1" align="right">
                                    &nbsp;<asp:Button ID="btnSendSMS" runat="server" Text="Send SMS" /><br />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>    
</asp:Content>
