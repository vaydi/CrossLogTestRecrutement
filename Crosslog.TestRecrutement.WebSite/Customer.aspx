<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="Crosslog.TestRecrutement.WebSite.Customer" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Crosslog - Test recrutement</title>
    <style>
        body
        {
            font-family: Calibri;
            font-size: 12px;
        }

        .detail td
        {
            background-color: #CCC;
            margin: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 1000px; background-color: #F1F1F1; padding: 15px; margin: 15px; border: 1px solid #666; margin-left: auto; margin-right: auto; min-height: 600px;">

            <asp:Panel ID="pnlDetailClient" runat="server">
                <asp:Label ID="lblCustomerID" runat="server" Text="" Visible="False"></asp:Label>
                <table class="detail">
                    <tr>
                        <td>Nom</td>
                        <td>
                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Prenom</td>
                        <td>
                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Adresse</td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Code postal</td>
                        <td>
                            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Ville</td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Code Pays</td>
                        <td>
                            <asp:TextBox ID="txtCountryCode" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Email</td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                Display="Dynamic" ErrorMessage="Invalid email address" />
                        </td>
                    </tr>
                    <tr>
                        <td>Phone</td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right;">
                            <asp:Button ID="btRecord" runat="server" Text="Enregistrer" OnClick="btRecord_Click" /></td>
                    </tr>
                </table>
                <br/>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <br />
                <br />
            </asp:Panel>

            <asp:GridView ID="grdOrders" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" OnRowDataBound="grdOrders_RowDataBound" OnSelectedIndexChanged="grdOrders_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="OrderNumber" HeaderText="Numéro" />
                    <asp:BoundField DataField="LastName" HeaderText="Nom" />
                    <asp:BoundField DataField="FirstName" HeaderText="Prénom" />
                    <asp:BoundField DataField="OrderCount" HeaderText="Nombre commande" />
                    <asp:BoundField DataField="TotalAmount" HeaderText="Total commande" />
                </Columns>
                <EmptyDataTemplate>Aucune données chargées dans la grille grdOrders</EmptyDataTemplate>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="left" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>