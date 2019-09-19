<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NexTechTestApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="row" >
        <div class="col-md-4">
            <h2>Hackernews Articles</h2>
            <asp:Panel runat="server"  DefaultButton="btnSearch" >
                <Table>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblTime" runat="server" Text="" visible="false" ForeColor="green"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblError" runat="server" Text="" visible="false" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSearch" runat="server" Text="Search:" Font-Bold="true"/>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchTerm" runat="server" onfocus="this.select();"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblField" runat="server" Text="Field:" Font-Bold="true"/>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlField" runat="server">
                                <asp:ListItem Value="All">All</asp:ListItem>
                                <asp:ListItem Value="Title">Title</asp:ListItem>
                                <asp:ListItem Value="By">By</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" >
                            <asp:Button ID="btnGetArticles" runat="server" Text="Get Articles" AutoPostBack="True" style="float:left" UseSubmitBehavior="false" OnClientClick="this.disabled=true;" OnClick="btnGetArticles_Click" />
                            <asp:Button ID="btnReset" runat="server" Text="Reset" AutoPostBack="True" style="float:right" UseSubmitBehavior="false" OnClientClick="this.disabled=true;" OnClick="btnReset_Click" Enabled="false" />
                            <asp:Button ID="btnSearch" runat="server" Text="Search" AutoPostBack="True" style="float:right" UseSubmitBehavior="false" OnClientClick="this.disabled=true;" OnClick="btnSearch_Click" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4>
                            <asp:Label ID="lblResults" runat="server" Text="" visible="false" ForeColor="black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                         <asp:GridView ID="grdArticles" runat="server" AutoGenerateColumns="false" Width="800" OnDataBound="grdArticles_DataBound">
                            <Columns>
                                <asp:HyperLinkField HeaderText="Title" DataTextField="Title" DataNavigateUrlFields="Url" />
                                <asp:BoundField HeaderText="By" DataField="By" />
                            </Columns>
                        </asp:GridView>
                        </td>
                    </tr>
                </Table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
