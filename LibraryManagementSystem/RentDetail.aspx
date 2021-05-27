<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="RentDetail.aspx.cs" Inherits="LibraryManagementSystem.RentDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row mb-3 align-items-center">
        <div class="col-md-1">
            <asp:LinkButton CssClass="row justify-content-center  align-items-center" OnClick="btnBack_Click" runat="server">
                <i class="fas fa-chevron-left mb-1" style="font-size: 24px; color: black;"></i>
            </asp:LinkButton>
        </div>
        <div class="col-md-11">
            <h3>İşlem Detayı</h3>
        </div>
    </div>

    <div class="row d-flex align-items-center border mb-2 mt-2 ">
        <div class="col-md-2">
            <i class="fas fa-user-tie p-3 rounded" style="font-size: 24px; background-color: #808080; color: white"></i>
        </div>
        <div class="col-md-3 text-center">
            <ul class="list-unstyled pt-3 ml-2">
                <li>
                    <strong class="font-weight-bold">Ad Soyad</strong>
                </li>
                <li>
                    <asp:Label ID="labelFullName" Style="font-size: small;" runat="server">-</asp:Label>
                </li>
            </ul>
        </div>
        <div class="col-md-3 text-center">
            <ul class="list-unstyled pt-3 ml-2">
                <li>
                    <strong class="font-weight-bold" runat="server">Kullanıcı Adı</strong>
                </li>
                <li>
                    <asp:Label ID="labelUsername" Style="font-size: small;" runat="server">-</asp:Label>
                </li>
            </ul>
        </div>
        <div class="col-md-3 text-center">
            <ul class="list-unstyled pt-3 ml-2">
                <li>
                    <strong class="font-weight-bold" runat="server">Durumu</strong>
                </li>
                <li>
                    <asp:Label ID="labelStatus" Style="font-size: small;" runat="server">-</asp:Label>
                </li>
            </ul>
        </div>
    </div>

    <div class="row d-flex align-items-center border ">
        <div class="col-md-2">
            <i class="fas fa-book p-3 rounded" style="font-size: 24px; background-color: #808080; color: white"></i>
        </div>
        <div class="col-md-3 text-center">
            <ul class="list-unstyled pt-3 ml-2">
                <li>
                    <strong class="font-weight-bold">Kitap Adı</strong>
                </li>
                <li>
                    <asp:Label ID="labelBookName" Style="font-size: small;" runat="server">-</asp:Label>
                </li>
            </ul>
        </div>
        <div class="col-md-3 text-center">
            <ul class="list-unstyled pt-3 ml-2">
                <li>
                    <strong class="font-weight-bold" runat="server">Yazarı</strong>
                </li>
                <li>
                    <asp:Label ID="labelAuthor" Style="font-size: small;" runat="server">-</asp:Label>
                </li>
            </ul>
        </div>
         <div class="col-md-3 text-center">
            <ul class="list-unstyled pt-3 ml-2">
                <li>
                    <strong class="font-weight-bold" runat="server">Kategorisi</strong>
                </li>
                <li>
                    <asp:Label ID="labelCategory" Style="font-size: small;" runat="server">-</asp:Label>
                </li>
            </ul>
        </div>
    </div>

    



    <div class="row d-flex align-items-center border mt-2">
        <div class="col-md-4 text-center">
            <ul class="list-unstyled pt-3 ml-2">
                <li>
                    <strong class="font-weight-bold">Kiralanma Tarihi</strong>
                </li>
                <li>
                    <asp:Label ID="labelRentDate" Style="font-size: small;" runat="server">-- --</asp:Label>
                </li>
            </ul>
        </div>
        <div class="col-md-4 text-center">
            <ul class="list-unstyled pt-3 ml-2">
                <li>
                    <strong class="font-weight-bold" runat="server">Teslim Tarihi</strong>
                </li>
                <li>
                    <asp:Label ID="labelReturnDate" Style="font-size: small;" runat="server">-- --</asp:Label>
                </li>
            </ul>
        </div>
         <div class="col-md-4 text-center">
            <ul class="list-unstyled pt-3 ml-2">
                <li>
                    <strong class="font-weight-bold" runat="server">Son Teslim Tarihi</strong>
                </li>
                <li>
                    <asp:Label ID="labelDeadline" Style="font-size: small;" runat="server">-- --</asp:Label>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
