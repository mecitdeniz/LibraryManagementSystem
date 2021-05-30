<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="MyBooksList.aspx.cs" Inherits="LibraryManagementSystem.MyBooksList" %>
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
            <h3>Kitaplarım</h3>
        </div>
    </div>

    <div class="row d-flex border pl-2 pr-2 mt-1">
        <div class="col-12">
            <asp:LinkButton ID="LinkButton1" CssClass="p-1" runat="server" OnClick="btnShowNotReturned_Click">
            <p class="font-weight-bold">Teslim Edilmemiş Kitaplar</p>
            </asp:LinkButton>
            <asp:SqlDataSource ID="notReturnedBookListDataSource" runat="server"
                ConnectionString="<%$ ConnectionStrings:dbo.libraryManagementConnectionString %>"
                SelectCommand="SELECT RentBook.[ID],Books.[Name], Books.[Category], Books.[Author] FROM Books INNER JOIN  RentBook ON Books.[ID]=RentBook.[BookID]   WHERE [UserID] = @userID AND [isReturned] = 0">
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
                                <asp:Button ID="btnDetail1" CssClass="btn btn-secondary btn-sm mr-2" runat="server"
                                    CommandName="BOOKDETAIL"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Detay"></asp:Button>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="row d-flex border pl-2 pr-2 mt-1">
        <div class="col-12">
            <asp:LinkButton ID="LinkButton2" CssClass="p-1" runat="server" OnClick="btnShowNotReturned_Click">
                <p class="font-weight-bold">Teslim Edilmiş Kitaplar</p>
            </asp:LinkButton>

            <asp:SqlDataSource ID="returnedBookListDataSource" runat="server"
                ConnectionString="<%$ ConnectionStrings:dbo.libraryManagementConnectionString %>"
                SelectCommand="SELECT RentBook.[ID],Books.[Name], Books.[Category], Books.[Author] FROM Books INNER JOIN  RentBook ON Books.[ID]=RentBook.[BookID]   WHERE [UserID] = @userID AND [isReturned] = 1">
                <SelectParameters>
                    <asp:QueryStringParameter Name="userID" QueryStringField="userID" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="gridViewReturnedBookList" class="table table-striped table-bordered" runat="server"
                AutoGenerateColumns="False"
                OnRowCommand="gridViewReturnedBookListRowCommand"
                DataSourceID="returnedBookListDataSource">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Ad" SortExpression="Name" />
                    <asp:BoundField DataField="Author" HeaderText="Yazar" SortExpression="Author" />
                    <asp:BoundField DataField="Category" HeaderText="Kategori" SortExpression="Category" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="d-flex justify-content-end align-items-center">
                                <asp:Button ID="btnDetail2" CssClass="btn btn-secondary btn-sm mr-2" runat="server"
                                    CommandName="BOOKDETAIL"
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                    Text="Detay"></asp:Button>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
