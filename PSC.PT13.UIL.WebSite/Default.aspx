<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    
</head>

<body>
    <form id="form1" runat="server">        
        <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>
        <script language="javascript" type="text/javascript">
            var m = 1;
            function selectMenu(menu) {
                document.all("1").style.display = "none";
                document.all("2").style.display = "none";
                document.all("3").style.display = "none";
                document.all("4").style.display = "none";
                document.all("5").style.display = "none";
                document.all("6").style.display = "none";
                var pnl = document.getElementById(menu.toString());
                pnl.style.display = "block";
                m = menu;
            }
        </script>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">        
            <ContentTemplate>
                <div>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <a href="javascript: void(0);" onclick="selectMenu(1)">ค้นหาบัญชี</a><br />
                                <a href="javascript: void(0);" onclick="selectMenu(2)">เปิดบัญชี</a><br />
                                <a href="javascript: void(0);" onclick="selectMenu(3)">ปิดบัญชี</a><br />
                                <a href="javascript: void(0);" onclick="selectMenu(4)">ฝากเงิน</a><br />
                                <a href="javascript: void(0);" onclick="selectMenu(5)">ถอนเงิน</a><br />
                                <a href="javascript: void(0);" onclick="selectMenu(6)">โอนเงิน</a><br />
                            </td>
                            <td style="padding-left: 20px;">
                                <div id="1" style="display: block;">
                                    <asp:Label ID="lblAccountNo1" Text="เลขที่บัญชี" runat="Server"></asp:Label><asp:TextBox ID="txtAccountNo1" runat="Server"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btnSearch" Text="ค้นหา" runat="Server" OnClick="btnSearch_Click" />
                                    <br />
                                    <asp:GridView ID="grdResult" runat="Server" Width="100%" AutoGenerateColumns="False">
                                        <AlternatingRowStyle BackColor="Oldlace" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>เลขที่บัญชี</HeaderTemplate>
                                                <ItemTemplate><asp:Label ID="lblAccountNo" Text='<%# DataBinder.Eval(Container, "DataItem.AccountNo") %>' runat="Server"></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>ยอดเงิน</HeaderTemplate>
                                                <ItemTemplate><asp:Label ID="lblBalance" runat="Server" Text='<%# Convert.ToDecimal(DataBinder.Eval(Container, "DataItem.Money")).ToString("#,##0.00") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div id="2" style="display: block;">
                                    <asp:Label ID="lblAccountNo2" Text="เลขที่บัญชี" runat="Server"></asp:Label><asp:TextBox ID="txtAccountNo2" runat="Server"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btnOpen" Text="เปิดบัญชี" runat="Server" OnClick="btnOpen_Click" />
                                </div>
                                <div id="3" style="display: block;">
                                    <asp:Label ID="lblAccountNo3" Text="เลขที่บัญชี" runat="Server"></asp:Label><asp:TextBox ID="txtAccountNo3" runat="Server"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btnClose" Text="ปิดบัญชี" runat="Server" OnClick="btnClose_Click" />
                                </div>
                                <div id="4" style="display: block;">
                                    <asp:Label ID="lblAccount4" Text="เลขที่บัญชี" runat="Server"></asp:Label><asp:TextBox ID="txtAccountNo4" runat="Server"></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="lblMoney4" Text="จำนวนเงิน" runat="Server"></asp:Label><asp:TextBox ID="txtMoney4" runat="Server"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btnDeposit" Text="ฝากเงิน" runat="Server" OnClick="btnDeposit_Click" />
                                </div>
                                <div id="5" style="display: block;">
                                    <asp:Label ID="lblAccountNo5" Text="เลขที่บัญชี" runat="Server"></asp:Label><asp:TextBox ID="txtAccountNo5" runat="Server"></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="lblMoney5" Text="จำนวนเงิน" runat="Server"></asp:Label><asp:TextBox ID="txtMoney5" runat="Server"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btnWithdraw" Text="ถอนเงิน" runat="Server" OnClick="btnWithdraw_Click" />                            
                                </div>
                                <div id="6" style="display: block;">
                                    <asp:Label ID="lblAccountNo6" Text="เลขที่บัญชีต้นทาง" runat="Server"></asp:Label><asp:TextBox ID="txtAccountNo6" runat="Server"></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="lblAccountNo7" Text="เลขที่บัญชีปลายทาง" runat="Server"></asp:Label><asp:TextBox ID="txtAccountNo7" runat="Server"></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="Label2" Text="จำนวนเงิน" runat="Server"></asp:Label><asp:TextBox ID="txtMoney6" runat="Server"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btnTransfer" Text="โอนเงิน" runat="Server" OnClick="btnTransfer_Click" />                                                        
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>                
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
