<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="LibraryManagementSystem.AddUser" %>

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
            <h3>Öğrenci Ekle</h3>
        </div>
    </div>
    <div class="pt-3 for pl-3 pr-3">
        <form>
            <div class="form-group">
                <label>Ad Soyad</label>
                <input type="email" class="form-control" placeholder="Mecit Deniz">
            </div>
            <div class="form-group">
                <label>Okul Numarası</label>
                <input type="number" class="form-control">
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Şifre</label>
                <input type="password" class="form-control" placeholder="Şifre">
            </div>
            <div class="form-group pl-4 mb-lg-5">
                <asp:CheckBox runat="server" CssClass="form-check-input" Text="Admin Olarak Kaydet" />
            </div>
            <asp:Button type="submit" CssClass="btn btn-success btn btn-block" runat="server" Text="Kaydet" />

        </form>
    </div>
</asp:Content>
