<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pending.aspx.vb" Inherits="Web_User_pending" MasterPageFile="~/MasterUser.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   <br/>
   <table style="width: 100%;">
        <tr valign="top">
            <td class="style2" style="width: 21px">
            </td>
            <td>
                <strong>View
                Pending SMS
                <br />
                </strong>
            </td>
            <td>
            </td>
        </tr>
        <tr valign="top">
            <td class="style2" style="width: 21px; height: 292px;">
                <span style="color: #000000"></span>
            </td>
            <td style="height: 292px">
                <asp:GridView ID="grdData" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="10" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="pendingSMSID" HeaderText="Sent SMS ID" />
                        <asp:BoundField DataField="message" HeaderText="Sent Message" />
                        <asp:BoundField DataField="ownerID" HeaderText="OwnerID" />
                        <asp:BoundField DataField="destinationAddress" HeaderText="Destination Number" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Label ID="lblDataGird" runat="server"></asp:Label></td>
            <td style="height: 292px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2" style="width: 21px">
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
