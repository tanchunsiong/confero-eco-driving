<%@ Page Language="VB" AutoEventWireup="false" CodeFile="applications.aspx.vb" Inherits="Web_User_applications" MasterPageFile="~/MasterUser.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <br />
    <table style="width: 100%">
        <tr valign="top">
            <td class="style4" style="width: 20px">
            </td>
            <td class="style4" colspan="2">
                <strong>My Application<br />
                    <br />
                </strong>
            </td>
            <td>
            </td>
        </tr>
        <tr valign="top">
            <td class="style4" style="width: 20px">
            </td>
            <td class="style4" colspan="2">
                <asp:GridView ID="grdData" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="1" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="AppID" HeaderText="Application ID" />
                        <asp:BoundField DataField="MessageSubscriptionID" HeaderText="Message Subscription ID" />
                        <asp:BoundField DataField="AppName" HeaderText="Application Name" />
                        <asp:BoundField DataField="NoOfSMS" HeaderText="Number of SMS Received" />
                    </Columns>
                </asp:GridView>
                <br />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4" style="width: 20px">
                &nbsp;
            </td>
            <td class="style4" style="width: 20px" valign="top">
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList></td>
            <td>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="btnChangeCode" runat="server" Text="Change current Code" />
                <asp:Label ID="lblNotice" runat="server" ForeColor="Red"></asp:Label><br />
                <br />
                When a user sends a code to the SMS gateway, it will be recognised via the code.
                Example a user sends a message "01 This is my message", the system will recognise
                the prefix "01" belongs to a specific
                user. The above function allows you set the code you wish people to prefix in front
                of their message.</td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
