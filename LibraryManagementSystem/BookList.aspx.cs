using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class BookList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (this.Master as Site1).changeButtonCss("btnBookList");
        }

        protected void gridViewBookListRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UPDATEBOOK")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                
                GridViewRow row = gridViewBookList.Rows[index];

                int id = int.Parse(row.Cells[0].Text.ToString());
                Response.Redirect("UpdateBook.aspx?bookID=" + id);
            }

            if (e.CommandName == "DELETE")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gridViewBookList.Rows[index];
                int id = int.Parse(row.Cells[0].Text.ToString());
                bookListDataSource.DeleteCommand = "DELETE FROM Books WHERE ID = '" + id + "'";
            }
        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddBook.aspx");
        }
    }
}