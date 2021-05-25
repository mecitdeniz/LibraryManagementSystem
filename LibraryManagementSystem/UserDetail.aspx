<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="LibraryManagementSystem.UserDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "pageLength": 3,
                "lengthMenu": [3],
                "language": {
                    "lengthMenu": "Sayfa başına _MENU_ kayıt",
                    "zeroRecords": "Hiçbir kayıt bulunamadı - Üzgünüm",
                    "info": "Sayfa _PAGE_ de _PAGES_",
                    "infoEmpty": "Hiçbir kayıt bulunamadı",
                    "infoFiltered": "( _MAX_ kayıt arasından filtrelendi)",
                    "search": "Ara",
                    "paginate": {
                        "next": "Sonraki",
                        "previous": "Önceki"
                    }
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3 align-items-center">
        <div class="col-md-1">
            <asp:LinkButton CssClass="row justify-content-center  align-items-center" OnClick="btnBack_Click" runat="server">
                <i class="fas fa-chevron-left mb-1" style="font-size: 24px; color: black;"></i>
            </asp:LinkButton>
        </div>
        <div class="col-md-11">
            <h3>Öğrenci Detay</h3>
        </div>
    </div>
    <div class="row d-flex align-items-center border pl-3">
        <i class="fas fa-user-tie p-3 rounded" style="font-size: 24px; background-color: #808080; color: white"></i>
        <ul class="list-unstyled pt-3 ml-2">
            <li>
                <asp:Label ID="labelFullName" CssClass="font-weight-bold" runat="server"></asp:Label>
            </li>
            <li>
                <asp:Label ID="labelBoxUserName" Style="font-size: small;" runat="server"></asp:Label>
            </li>
        </ul>
    </div>
    <div class="row d-flex align-items-center border pl-3 pr-3 mt-1">
        <asp:LinkButton ID="LinkButton1" CssClass="p-1" runat="server" OnClick="btnShowNotReturned_Click">
            <p class="font-weight-bold">Teslim Edilmemiş Kitaplar</p>
        </asp:LinkButton>
        <asp:SqlDataSource ID="notReturnedBookListDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:dbo.libraryManagementConnectionString %>"
            SelectCommand="SELECT [ID], [Name], [Category], [Author] FROM [Books] WHERE [ID] IN (SELECT [BookID] FROM RentBook WHERE [UserID] = @userID AND [isReturned] = 0)">
            <SelectParameters>
                <asp:QueryStringParameter Name="userID" QueryStringField="userID" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:GridView ID="gridViewNotReturnedBookList" class="table table-striped table-bordered" runat="server"
            AutoGenerateColumns="False"
            OnRowCommand="gridViewBookListRowCommand"
            DataSourceID="notReturnedBookListDataSource">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Ad" SortExpression="Name" />
                <asp:BoundField DataField="Author" HeaderText="Yazar" SortExpression="Author" />
                <asp:BoundField DataField="Category" HeaderText="Kategori" SortExpression="Category" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="d-flex justify-content-end align-items-center">
                            <asp:Button ID="btnaccept" CssClass="btn btn-success btn-sm mr-2" runat="server"
                                CommandName="UPDATEBOOK"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                Text="Teslim Al"></asp:Button>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <div class="row d-flex align-items-center border pl-3 pr-3 mt-1">
        <asp:LinkButton ID="LinkButton2" CssClass="p-1" runat="server" OnClick="btnShowNotReturned_Click">
            <p class="font-weight-bold">Teslim Edilmiş Kitaplar</p>
        </asp:LinkButton>
        <asp:SqlDataSource ID="returnedBookListDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:dbo.libraryManagementConnectionString %>"
            SelectCommand="SELECT [ID], [Name], [Category], [Author] FROM [Books] WHERE [ID] IN (SELECT [BookID] FROM RentBook WHERE [UserID] = @userID AND [isReturned] = 1)">
            <SelectParameters>
                <asp:QueryStringParameter Name="userID" QueryStringField="userID" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="gridViewReturnedBookList" class="table table-striped table-bordered" runat="server"
            AutoGenerateColumns="False"
            DataSourceID="returnedBookListDataSource">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Ad" SortExpression="Name" />
                <asp:BoundField DataField="Author" HeaderText="Yazar" SortExpression="Author" />
                <asp:BoundField DataField="Category" HeaderText="Kategori" SortExpression="Category" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
