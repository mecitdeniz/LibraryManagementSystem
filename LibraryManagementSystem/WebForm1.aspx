<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LibraryManagementSystem.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row p-5 rounded login-form-container bg-transparent">
        <div class="col-md-6 shadow-sm text-center p-5 rounded-left"
            style="background-color: #0063D7;">
            <img class="shadow-lg rounded-circle mt-5" src="./src/assets/logo.png" width="100" />
            <h3 class="font-weight-bold mt-3" style="color: white;">IESU Kütüphane Yönetim Sistemi</h3>
        </div>
        <div class="col-md-6 shadow-sm p-5 rounded-right " style="background-color: white;">
            <h4 class="font-weight-bold" style="color: #0063D7;">Giriş Yap</h4>
            <div class="p-lg-3 mt-5">
                <div class="form-group row rounded align-items-center">
                    <i class="fas fa-user ml-3" style="font-size: 24px;"></i>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" id="username" placeholder="Kullanıcı Adı">
                    </div>
                </div>

                <div class="form-group row rounded align-items-center">
                    <i class="fas fa-lock ml-3" style="font-size: 24px;"></i>
                    <div class="col-sm-10">
                        <input type="password" class="form-control" id="password" placeholder="Şifre">
                    </div>
                </div>

                <div class="form-group">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" id="gridCheck">
                        <label class="form-check-label" for="gridCheck">
                            Yönetici Girişi
                        </label>
                    </div>
                </div>
                <button type="button" class="btn  btn-block mt-4 " style="background-color:#0063D7; color:white;">Giriş Yap</button>
            </div>
        </div>
    </div>
</asp:Content>
