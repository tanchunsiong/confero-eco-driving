<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UploadFile.aspx.vb" Inherits="web_admin_Setting_UploadFile" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<br/>
    <table width="970" align="center">
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblTitle" runat="server" Text="Upload File" CssClass="title_label"></asp:Label><br/><br/>
            </td>
        </tr>
        <tr>
            <td colspan="3"> 
                <asp:Label ID="lblStatus" runat="server" Text="Status: No file uploaded" CssClass="normal_label"></asp:Label><br/>    
                <br />
            </td>
        </tr>   
        <tr>
            <td colspan="3" style="height: 21px"> 
                <asp:Panel ID="pnlVideo" runat="server" GroupingText="Upload PDF File" Height="145px"
                    Width="628px">
                    <table>
                        <tr>
                            <td style="width: 19px; height: 65px">
                            </td>
                            <td style="width: 89px; height: 65px">
                <asp:Label ID="Label1" runat="server" CssClass="normal_label" Font-Underline="False"
                    Text="For:"></asp:Label></td>
                            <td style="width: 437px; height: 65px">
                                &nbsp;<asp:RadioButtonList ID="radFile" runat="server">
                    <asp:ListItem Selected="True" Value="specifications.pdf">Hardware Specifications</asp:ListItem>
                    <asp:ListItem Value="userguide.pdf">User Guide</asp:ListItem>
                </asp:RadioButtonList></td>
                            <td style="height: 65px">
                                &nbsp;<asp:FileUpload ID="browseFile" runat="server" /></td>
                            <td style="width: 109px; height: 65px">
                                &nbsp;<asp:Button ID="btnFile" runat="server" Text="Upload" Width="81px" /></td>
                        </tr>
                    </table>
                </asp:Panel>
                   
            </td>
        </tr>
        
        <tr>
            <td colspan="3"> 
                <asp:Panel ID="Panel1" runat="server" GroupingText="Upload Video File" Height="108px"
                    Width="628px">
                    <table>
                        <tr>
                            <td style="width: 19px; height: 53px">
                            </td>
                            <td style="width: 89px; height: 53px">
                <asp:Label ID="Label3" runat="server" CssClass="normal_label" Font-Underline="False"
                    Text="For:"></asp:Label></td>
                            <td style="width: 437px; height: 53px">
                                &nbsp;<asp:RadioButtonList ID="radVideo" runat="server">
                    <asp:ListItem Selected="True" Value="video1.flv">Video 1</asp:ListItem>
                    <asp:ListItem Value="video2.flv">Video 2</asp:ListItem>
                </asp:RadioButtonList>
                </td>
                            <td style="height: 53px">
                                <asp:FileUpload ID="browseVideo" runat="server" />&nbsp;</td>
                            <td style="width: 109px; height: 53px">
                                &nbsp;<asp:Button ID="btnVideo" runat="server" Text="Upload" Width="81px" /></td>
                        </tr>
                    </table>
                </asp:Panel>
                   
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
    </table>
</asp:Content>


