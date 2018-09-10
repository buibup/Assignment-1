<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /* cellpadding */
        th, td {
            padding: 5px;
        }

        /* cellspacing */
        table {
            border-collapse: separate;
            border-spacing: 5px;
        }
        /* cellspacing="5" */
        table {
            border-collapse: collapse;
            border-spacing: 0;
        }
        /* cellspacing="0" */

        /* valign */
        th, td {
            vertical-align: top;
        }

        /* align (center) */
        table {
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblSearch" Text="AccoutNo/Balance" runat="Server"></asp:Label>&nbsp;&nbsp;
                        <asp:TextBox ID="txtSearch" runat="Server"></asp:TextBox>&nbsp;&nbsp;
                        <asp:Button ID="btnSearch" Text="ค้นหา" runat="Server" OnClick="btnSearchOr_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAccoutNoSearch" Text="AccoutNo" runat="Server"></asp:Label>&nbsp;&nbsp;
                        <asp:TextBox ID="txtAccoutNoSearch" runat="Server"></asp:TextBox>&nbsp;&nbsp;
                        <asp:Label ID="lblBalanceSearch" Text="Balance" runat="Server"></asp:Label>&nbsp;&nbsp;
                        <asp:TextBox ID="txtBalanceSearch" runat="Server"></asp:TextBox>&nbsp;&nbsp;
                        <asp:Button ID="btnSearchAnd" Text="ค้นหา" runat="Server" OnClick="btnSearchAnd_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="AccountNo"
                            OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"
                            OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records.">
                            <Columns>
                                <asp:TemplateField HeaderText="AccountNo" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAccountNo" runat="server" Text='<%# Eval("AccountNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtAccountNo" runat="server" Text='<%# Eval("AccountNo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Balance" ItemStyle-Width="150">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("Money") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtBalance" runat="server" Text='<%# Eval("Money") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150" />
                            </Columns>
                        </asp:GridView>
                        <table border="1" style="border-collapse: collapse">
                            <tr>
                                <td style="width: 150px">AccountNo<br />
                                    <asp:TextBox ID="txtAccountNo" runat="server" Width="140" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                        ControlToValidate="txtAccountNo" runat="server"
                                        ErrorMessage="Only Numbers allowed"
                                        ValidationExpression="\d+">
                                    </asp:RegularExpressionValidator>
                                </td>
                                <td style="width: 150px">Balance<br />
                                    <asp:TextBox ID="txtBalance" runat="server" Width="140" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                        ControlToValidate="txtBalance" runat="server"
                                        ErrorMessage="Only Numbers allowed"
                                        ValidationExpression="\d+">
                                    </asp:RegularExpressionValidator>
                                </td>
                                <td style="width: 100px">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
