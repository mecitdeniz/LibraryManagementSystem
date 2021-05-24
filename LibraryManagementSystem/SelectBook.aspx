<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="SelectBook.aspx.cs" Inherits="LibraryManagementSystem.SelectBook" %>

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
            <h3>Kitap Seç</h3>
        </div>
    </div>


    <div class="row">
        <div class="col">
            <asp:SqlDataSource ID="bookListDataSource" runat="server"
                ConnectionString="<%$ ConnectionStrings:dbo.libraryManagementConnectionString %>"
                SelectCommand="SELECT ID, Name, Category, Author FROM Books WHERE (ID NOT IN (SELECT BookID FROM RentBook WHERE (isReturned = 0)))"></asp:SqlDataSource>
            <asp:GridView ID="gridViewBookList" class="table table-striped table-bordered" runat="server"
                AutoGenerateColumns="False"
                OnRowCommand="gridViewBookListRowCommand"
                DataSourceID="bookListDataSource">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Ad" SortExpression="Name" />
                    <asp:BoundField DataField="Author" HeaderText="Yazar" SortExpression="Author" />
                    <asp:BoundField DataField="Category" HeaderText="Kategori" SortExpression="Category" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="d-flex justify-content-end align-items-center">
                                <asp:Button ID="btnaccept" CssClass="btn btn-primary btn-sm mr-2" runat="server"
                                    CommandName="SELECTBOOK"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Seç"></asp:Button>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </div>
</asp:Content>
