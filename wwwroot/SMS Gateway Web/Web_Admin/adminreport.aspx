<%@ Page Language="VB" AutoEventWireup="false" CodeFile="adminreport.aspx.vb" Inherits="Web_Admin_adminreport" MasterPageFile="~/MasterAdmin.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString %>"
        SelectCommand="SELECT [id], [monthyear] FROM [tbl_runningMonths]"></asp:SqlDataSource>
  
     <table style="width: 100%">
            <tr>
                <td style="width: 20px">
                </td>
                <td colspan="5">
                    <strong>View all received SMS</strong>&nbsp;<br />
                </td>
            </tr>
         <tr>
             <td style="width: 20px">
             </td>
             <td colspan="5">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                    DataTextField="monthyear" DataValueField="id">
                </asp:DropDownList>&nbsp;
                <asp:Button ID="btnDeleteRec" runat="server" Text="Delete All*" /></td>
         </tr>
            <tr>
                <td style="width: 20px">
                </td>
                <td colspan="5">
                <asp:GridView ID="DataGrid1" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                    Font-Size="Smaller" PageSize="20" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="processedReceivedSMS" HeaderText="Received SMS ID" />
                        <asp:BoundField DataField="message" HeaderText="Received Message" />
                        <asp:BoundField DataField="SourcePhoneNumber" HeaderText="Received From Mobile Number" />
                        <asp:BoundField DataField="datetimereceived" HeaderText="Date time received" />
                        <asp:BoundField DataField="receivedByUserID" HeaderText="Redirected to user" />
                    </Columns>
                </asp:GridView>
                    <br />
                    <asp:Label ID="lblDataGird" runat="server"></asp:Label><br />
                    <br />
            </td>
            </tr>
            <tr>
                <td style="width: 20px;">
                </td>
                <td colspan="5">
                    <strong>View all sent SMS<br />
                    </strong>
                </td>
            </tr>
            <tr>
                <td style="width: 20px">
                </td>
                <td colspan="5">
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                    DataTextField="monthyear" DataValueField="id">
                </asp:DropDownList>
                <asp:Button ID="btnDeleteSent" runat="server" Text="Delete All*" /></td>
            </tr>
         <tr>
             <td style="width: 20px">
             </td>
             <td colspan="5">
                <asp:GridView ID="DataGrid2" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                    Font-Size="Smaller" PageSize="20" Width="100%">
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
                 <asp:Label ID="lblDataGird2" runat="server"></asp:Label></td>
         </tr>
        </table>
</asp:Content>


