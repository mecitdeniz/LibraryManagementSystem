using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class SelectBook : System.Web.UI.Page
    {
        private int userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["userID"]))
            {
                userID = Int32.Parse(Request.QueryString["userID"]);
            }
            else
            {
                goBack();
            }
        }
        protected void gridViewBookListRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SELECTBOOK")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gridViewBookList.Rows[index];

                int bookID = int.Parse(row.Cells[0].Text.ToString());
                rentBook(bookID);
            }
        }

        public void goBack()
        {
            Response.Redirect("SelectUser.aspx");
        }

        private void rentBook(int bookID)
        {
            if (userID.Equals(null) || bookID.Equals(null)) return;
            try
            {
                Database db = new Database();
                SqlCommand command = new SqlCommand("INSERT INTO RentBook(BookID,UserID) VALUES(@BookID,@UserID)", db.Connection());
                command.Parameters.AddWithValue("@BookID",bookID);
                command.Parameters.AddWithValue("@UserID",userID);

                command.ExecuteNonQuery();
              
                db.Connection().Close();
                Response.Write("<script>alert('Kitap başarılı bir şekilde kiralandı');</script>");
                goBack();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}