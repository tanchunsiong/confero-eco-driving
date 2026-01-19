<%@ Page Language="VB" AutoEventWireup="false" CodeFile="addapplications.aspx.vb" Inherits="Web_User_addapplications" MasterPageFile="~/MasterUser.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    &nbsp;<table style="width: 100%; color: #000000">
        <tr valign="top">
            <td class="style4" style="width: 23px">
                <a href=" applications.aspx"><span style="color: #000000"></span></a>
            </td>
            <td>
                <asp:Panel ID="pnlSearch" runat="server" GroupingText="Add Application" Height="299px"
                    Width="601px">
                    <table>
                        <tr>
                            <td style="width: 19px; height: 32px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtAppName"></asp:RequiredFieldValidator></td>
                            <td colspan="4" style="height: 32px; width: 187px;">
                                Application Name</td>
                            <td colspan="1" style="height: 32px; width: 36px;">
                <asp:TextBox ID="txtAppName" runat="server" Width="167px" ></asp:TextBox></td>
                            <td colspan="1" style="width: 166px; height: 32px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 19px; height: 32px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtSubID"></asp:RequiredFieldValidator></td>
                            <td colspan="4" style="width: 187px" >
                Message Subscription ID</td>
                            <td colspan="1" style="height: 32px; width: 36px;">
                <asp:TextBox ID="txtSubID" runat="server" Width="169px"></asp:TextBox></td>
                            <td colspan="1" style="width: 166px; height: 32px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 19px; height: 32px">
                            </td>
                            <td colspan="4" style="height: 32px; width: 187px;">
                            </td>
                            <td colspan="1" style="width: 36px" >
                <asp:Button ID="btnChangeCode" runat="server" Text="Add new Application"/></td>
                            <td align="right" colspan="1" style="width: 166px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 19px; height: 32px">
                            </td>
                            <td colspan="6" style="height: 32px">
                <asp:Label ID="lblNotice" runat="server" ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 19px; height: 32px">
                            </td>
                            <td colspan="6" style="height: 32px">
                When a user sends a code to the SMS gateway, it will be recognised via the code.
                                <br />
                                <br />
                Example a user sends a message "01 This is my message", the system will recognise
                the prefix "01" belongs to a specific
                user. The above function allows you set the code you wish people to prefix in front
                of their message.</td>
                        </tr>
                    </table>
                </asp:Panel>
                &nbsp;<br />
                &nbsp;<br />
                <br />
                <br />
                <br />
                <br />
                </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style4" style="width: 23px">
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
