<%@ Page Title="" Language="C#" MasterPageFile="~/Tech2019User.Master" AutoEventWireup="true" CodeBehind="Tech2019.WebFormContent.aspx.cs" Inherits="Tech2019.WebLayer.Tech2019_WebFormContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .center-block {
            margin: auto;
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
        }

        .form-inline {
            display: flex;
            align-items: center;
            gap: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid center-block">
        <div class="form-inline">
            <asp:Label ID="Label1" runat="server" Text="Ürün Seri Numarası : " Font-Bold="True"></asp:Label>
            <asp:TextBox ID="TxtProductSerialNumber" runat="server"></asp:TextBox>
            <asp:Button ID="BtnSearch" runat="server" Text="Ara" CssClass="btn btn-primary" OnClick="BtnSearch_Click" />
        </div>
    </div>

    <table class="table table-bordered" style="margin-top: 30px">
        <tr>
            <th>ÜÜRÜN TAKİP DETAYI</th>
            <th>TAKİP TARİHİ</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>

                <tr>
                    <td><%# Eval("ProductTraceInformation") %></td>
                    <td><%# Eval("ProductTraceDate") %></td>
                </tr>

            </ItemTemplate>
        </asp:Repeater>
    </table>

</asp:Content>

