<%@ Page Language="VB" AutoEventWireup="false" CodeFile="received.aspx.vb" Inherits="Web_User_received" MasterPageFile="~/MasterUser.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    &nbsp;
    <table style="width: 100%">
        <tr valign="top">
            <td class="style2" style="width: 20px">
            </td>
            <td>
                <strong>User received sms<br />
                </strong>
            </td>
            <td>
            </td>
        </tr>
        <tr valign="top">
            <td class="style2" style="width: 20px">
            </td>
            <td>
                <asp:GridView ID="grdData" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Font-Size="Smaller" PageSize="10" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="processedReceivedSMS" HeaderText="Received SMS ID" />
                        <asp:BoundField DataField="message" HeaderText="Received Message" />
                        <asp:BoundField DataField="SourcePhoneNumber" HeaderText="Received From Mobile Number" />
                        <asp:BoundField DataField="datetimereceived" HeaderText="Date time received" />
                        <asp:BoundField DataField="receivedByUserID" HeaderText="Redirected to user" />
                        <asp:BoundField DataField="messageSubscriptionID" HeaderText="Message Subscription" />
                    </Columns>
                </asp:GridView>
                &nbsp;<br />
                <asp:Label ID="lblDataGird" runat="server"></asp:Label></td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2" style="width: 20px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>


