<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="LibraryManagementSystem.ChangePassword" %>
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
            <h3>Şifre Güncelle</h3>
        </div>
    </div>
    <div class="pt-3 for pl-3 pr-3">
        <form>
            <div class="form-group">
                <label>Eski Şifre</label>
                <asp:TextBox  ID="textBoxPassword" TextMode="Password" CssClass="form-control" runat="server"/>
            </div>
            <div class="form-group">
                <label>Yeni Şifre</label>
                <asp:TextBox ID="textBoxNewPassword" TextMode="Password" CssClass="form-control" runat="server"/>
            </div> 
            <div class="form-group">
                <label for="textBoxPassword">Yeni Şifre Doğrulama</label>
                <asp:TextBox ID="textBoxConfirmPassword" TextMode="Password" CssClass="form-control"  runat="server"/>
            </div>
          
            <asp:Button  CssClass="btn btn-success btn btn-block" runat="server" OnClick="btnUpdatePassword_Click" Text="Güncelle" />
        </form>
    </div>
</asp:Content>
