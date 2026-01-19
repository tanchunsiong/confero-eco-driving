<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ManageUsers.aspx.vb" Inherits="Web_Admin_ManageUsers" MasterPageFile="~/MasterAdmin.master" %>


      
        
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

 <script event="onclick" for="chkRecordId" language="javascript">
    
        var intIndex = new Number(0);
        var intMaxIndex = new Number(0);
        var aryControls = new Array();
        var intNumOfSelection = new Number(0);
       
          
          if (window.event.srcElement.value==0) { 
        aryControls =window.document.getElementsByName("chkRecordId");
        
        intMaxIndex = aryControls.length -1;
        
       if (aryControls[0].checked==true)
       {
            for (intIndex=1 ; intIndex<=intMaxIndex ; intIndex++){
                aryControls[intIndex].checked=true;
            }//for
            
       } 
       
       else if (aryControls[0].checked==false)
       {
            for (intIndex=1 ; intIndex<=intMaxIndex ; intIndex++){
                aryControls[intIndex].checked=false;
            }//for
       }
       } 
        

        </script>
        
            <div>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 65px" >
                            &nbsp; &nbsp;&nbsp;
                        </td>
                        <td colspan="5" style="width: 846px">
                            <strong>Users</strong></td>

                    </tr>
                    <tr>
                        <td style="width: 65px">
                        </td>
                        <td colspan="9" style="width: 846px">
                <asp:DataGrid ID="grdData" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                    Font-Size="Smaller" PageSize="10">
                    <Columns>
                        <asp:BoundColumn DataField="userID" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn DataField="counter" HeaderText=""></asp:BoundColumn>
                        <asp:BoundColumn></asp:BoundColumn>
                        <asp:BoundColumn DataField="userName" HeaderText="User Name"></asp:BoundColumn>
                        <asp:BoundColumn DataField="password" HeaderText="Password"></asp:BoundColumn>
                        <asp:BoundColumn DataField="currentUsage" HeaderText="Total number of SMS sent to date">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SMSLeft" HeaderText="Number of SMS left in account"></asp:BoundColumn>
                        <asp:BoundColumn DataField="totalLimit" HeaderText="Total number of SMS issued to user to date">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NoOfSMSReceived" HeaderText="Total Number Of SMS Received to date">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="type" HeaderText="Type of User"></asp:BoundColumn>
                        <asp:BoundColumn DataField="status" HeaderText="Current Status"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid><br />
                        </td>

                    </tr>
                    <tr>
                        <td style="width: 65px">
                        </td>
                        <td colspan="5" style="width: 846px">
                            <strong>User Management Console<br />
                            </strong>
                        </td>
                        <td colspan="1" style="width: 848px">
                        </td>
                        <td colspan="1" style="width: 648px">
                        </td>
                        <td colspan="1" style="width: 902px">
                        </td>
                        <td colspan="1" style="width: 18564px">
                        </td>
                        <td colspan="1" style="width: 154700px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 65px; height: 20px">
                        </td>
                        <td colspan="5" style="height: 20px; width: 846px;">
                            <asp:Panel ID="pnlSearch" runat="server" GroupingText="Activation" Height="95px"
                                Width="296px">
                                <table>
                                    <tr>
                                        <td style="width: 19px; height: 32px">
                                        </td>
                                        <td colspan="4" style="height: 32px">
                                            <asp:Button ID="btnActivate" runat="server" Text="Activate User" />
                            <asp:Button ID="btnDisable" runat="server" Text="Disable User" Width="115px" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td colspan="1" style="height: 20px; width: 848px;">
                        </td>
                        <td colspan="1" style="width: 648px; height: 20px"><asp:Panel ID="Panel1" runat="server" GroupingText="Quota" Height="95px"
                                Width="296px">
                            <table>
                                <tr>
                                    <td style="width: 19px; height: 32px" valign="top">
                                        &nbsp;</td>
                                    <td colspan="4" style="height: 32px; width: 195px;">
                            <asp:TextBox ID="txtSMS" runat="server" Width="163px"></asp:TextBox>
                                        <br />
                            <asp:Button ID="btnIncrease" runat="server" Text="Increase" Width="83px" />
                            <asp:Button ID="btnDecrease" runat="server" Text="Decrease" />&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                        </td>
                        <td colspan="1" style="width: 902px; height: 20px">
                        </td>
                        <td colspan="1" style="width: 18564px; height: 20px"><asp:Panel ID="Panel2" runat="server" GroupingText="Promotion" Height="95px"
                                Width="296px">
                            <table>
                                <tr>
                                    <td style="width: 19px; height: 32px">
                                    </td>
                                    <td colspan="4" style="height: 32px; width: 257px;">
                                        &nbsp;<asp:Button ID="btnPromote" runat="server" Text="Promote to Admin" Width="124px" />
                            <asp:Button ID="Button4" runat="server" Text="Demote to User" Width="108px" /></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        </td>
                        <td colspan="1" style="width: 154700px; height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 65px; height: 20px">
                        </td>
                        <td colspan="9" style="height: 20px">
            <asp:Label ID="lblNotice" runat="server" ForeColor="Red"></asp:Label></td>
                        <td colspan="1" style="width: 154700px; height: 20px">
                        </td>
                    </tr>
                </table>
            </div>
            <br />
        
    </asp:Content>

