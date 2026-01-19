<%@ Page Language="VB" AutoEventWireup="false" CodeFile="sent.aspx.vb" Inherits="Web_User_sent" MasterPageFile="~/MasterUser.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <br/>
    <table style="width: 100%">
        <tr>
            <td class="style2" style="width: 20px">

            </td>
            <td >
                <strong>
                    View Sent SMS
                </strong>
            </td>
            <td>
                
            </td>
        </tr>
        <tr valign="top">
            <td class="style2" style="width: 20px">
                <span style="color: #000000"></span>
            </td>
            <td>
                <asp:GridView ID="grdData" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Font-Size="Smaller" PageSize="10" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="SentSMSID" HeaderText="Sent SMS ID" />
                        <asp:BoundField DataField="message" HeaderText="Sent Message" />
                        <asp:BoundField DataField="ownerID" HeaderText="OwnerID" />
                        <asp:BoundField DataField="destinationAddress" HeaderText="Destination Number" />
                        <asp:BoundField DataField="successful" HeaderText="Send Status" />
                        <asp:BoundField DataField="datetimesent" HeaderText="Date/Time Sent" />
                    </Columns>
                </asp:GridView>
                <br />
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

