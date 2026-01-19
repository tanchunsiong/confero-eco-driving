<%@ Page Language="VB" AutoEventWireup="false" CodeFile="user.aspx.vb" Inherits="Web_User_user" MasterPageFile="~/MasterUser.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <br/>
      <table style="width: 100%;">
            <tr>
                <td style="width: 20px; height: 375px;"></td>
                <td colspan="5" style="height: 375px">
                    <asp:Panel ID="pnlSearch" runat="server" GroupingText="Message Summary" 
                        Width="511px" Height="363px">
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
                <asp:Label ID="lblDelivered" runat="server"></asp:Label>
                &nbsp;<span style="text-decoration: underline">Successfully Delivered</span>&nbsp;(This might not be 
                                    accurate as not all service providers will provide status report. If it appears 
                                    0 all the way, its a high chance the the serice provider/ gsm modem does not 
                                    support status report)<br />
                                    <br />
                                    <asp:Label ID="lblReceived" runat="server"></asp:Label>
                                    &nbsp;<span style="text-decoration: underline">Received</span></td>
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
                    Message status :<br />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 32px">
                                </td>
                                <td colspan="4" style="height: 32px">
                <asp:Label ID="lblNotDelivered" runat="server"></asp:Label>
                                    &nbsp;Undeliverable Messages ((This might not be accurate as not all service 
                                    providers will provide status report. If it appears high all the way, its a high 
                                    chance the the serice provider/ gsm modem does not support status report)<br />
                                    <br />
                <asp:Label ID="lblPending" runat="server"></asp:Label>
                &nbsp;Messages Pending delivery</td>
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
                <asp:TextBox ID="txtMessage" runat="server" Height="134px" TextMode="MultiLine" Width="171px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 19px; height: 45px">
                                </td>
                                <td colspan="4" style="height: 45px" valign="top">
                                </td>
                                <td colspan="1" align="right" style="height: 45px">
                                    &nbsp;&nbsp;
                <asp:Button ID="btnSendSMS" runat="server" Text="Send SMS" /><br />
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>    
</asp:Content>
