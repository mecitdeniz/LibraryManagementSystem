<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="LibraryManagementSystem.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            //$(document).ready(function () {
            //$('.table').DataTable();
            // });

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "pageLength": 5,
                "lengthMenu": [5, 10],
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

            //$("#liBookList").addClass("active");
            //$('.table1').DataTable();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row mb-3">
        <div class="col-md-9">
            <h3>Öğrenci Listesi</h3>
        </div>
        <div class="col-md-3 d-flex align-items-center justify-content-end">
            <asp:Button CssClass="btn btn-success btn-sm" runat="server" OnClick="btnAddUser_Click" Text="Ekle" />
        </div>
    </div>


    <div class="row">
        <div class="col">
            <asp:SqlDataSource ID="userListDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:dbo.libraryManagementConnectionString %>" SelectCommand="SELECT [ID], [FullName], [Username] FROM [Users] WHERE ([isAdmin] = @isAdmin)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="false" Name="isAdmin" Type="Boolean" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="gridViewUserList" class="table table-striped table-bordered" runat="server"
                AutoGenerateColumns="False"
                OnRowCommand="gridViewUserListRowCommand"
                DataSourceID="userListDataSource">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                    <asp:BoundField DataField="FullName" HeaderText="Ad Soyad" SortExpression="FullName" />
                    <asp:BoundField DataField="Username" HeaderText="Okul Numarası" SortExpression="UserName" />
                    <%--<asp:CommandField ShowEditButton="true" />
                    <asp:CommandField ShowDeleteButton="true" />--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="d-flex justify-content-end align-items-center">
                                <asp:Button ID="btnViewUser" CssClass="btn btn-primary btn-sm mr-2" runat="server"
                                    CommandName="VIEWUSER"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Görüntüle"></asp:Button>
                                <asp:Button ID="btnUpdateUser" CssClass="btn btn-warning btn-sm mr-2" runat="server"
                                    CommandName="UPDATEUSER"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Güncelle"></asp:Button>
                                <asp:Button ID="btnDeleteUser" CssClass="btn btn-danger btn-sm" runat="server"
                                    CommandName="DELETE"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Sil" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </div>
</asp:Content>
