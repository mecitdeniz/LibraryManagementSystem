<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="LibraryManagementSystem.AddBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mb-3 align-items-center">
        <div class="col-md-1">
            <asp:LinkButton CssClass="row justify-content-center  align-items-center" OnClick="btnBack_Click" runat="server">
               <i class="fas fa-chevron-left mb-1" style="font-size:24px; color:black;"></i>
            </asp:LinkButton>
        </div>
        <div class="col-md-11">
            <h3>Kitap Ekle</h3>
        </div>
    </div>
    <div class="pt-3 for pl-3 pr-3">
        <form>
            <div class="form-group">
                <label>Kitap İsmi</label>
                <asp:TextBox ID="textBoxName" TextMode="SingleLine" CssClass="form-control" runat="server" />
            </div>
            <div class="form-group">
                <label>Yazarı</label>
                <asp:TextBox ID="textBoxAuthor" TextMode="SingleLine" CssClass="form-control" runat="server" />
            </div>
            <div class="form-group">
                <label for="textBoxPassword">Kategori</label>
                <asp:TextBox ID="textBoxCategory" TextMode="SingleLine" CssClass="form-control" runat="server" />
            </div>
            <asp:Button  CssClass="btn btn-success btn btn-block" runat="server" OnClick="btnSaveBook_Click" Text="Kaydet" />
        </form>
    </div>
</asp:Content>
