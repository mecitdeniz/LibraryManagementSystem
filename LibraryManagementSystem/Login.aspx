<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryManagementSystem.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row p-5 rounded bg-transparent ml-5 mr-5">
        <div class="col-md-6 shadow-sm text-center p-5 rounded-left"style="background-color: #0063D7;">
            <img class="shadow-lg rounded-circle mt-5" src="./src/assets/logo.png" width="100" />
            <h3 class="font-weight-bold mt-3" style="color: white;">IESU Kütüphane Yönetim Sistemi</h3>
        </div>
        <div class="col-md-6 shadow-sm p-5 rounded-right " style="background-color: white;">
            <h4 class="font-weight-bold" style="color: #0063D7;">Giriş Yap</h4>
            <div class="p-lg-3 mt-5">
                <div class="form-group row rounded align-items-center">
                    <i class="fas fa-user ml-3" style="font-size: 24px;"></i>
                    <div class="col-sm-10">
                          <asp:TextBox CssClass="form-control" ID="textBoxUsername" runat="server" placeHolder="Kullanıcı Adı"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row rounded align-items-center">
                    <i class="fas fa-lock ml-3" style="font-size: 24px;"></i>
                    <div class="col-sm-10">
                          <asp:TextBox CssClass="form-control" ID="textBoxPassword" TextMode="Password" runat="server" placeHolder="Şifre"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group mb-5">
                    <div class="form-check">
                        <asp:CheckBox CssClass="form-check-input"  ID="checkBoxAdmin" runat="server" Text="Yönetici Girişi"/>
                    </div>
                </div>
                <asp:Button CssClass="btn  btn-block mt-4" BackColor="#0063D7" ForeColor="White" ID="btnLogin" runat="server" Text="Giriş Yap" OnClick="btnLogin_Click" />
            </div>
        </div>
    </div>
</asp:Content>
