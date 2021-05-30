using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class AddBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (this.Master as Site1).changeButtonCss("btnBookList");
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            clearAddBookForm();
            goBack();
        }


        protected void btnSaveBook_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text != "" && textBoxCategory.Text != "" && textBoxCategory.Text != "")
            {
                saveBook();
            }
            else
            {
                Response.Write("<script>alert('Lütfen Formu Doldurunuz!');</script>");
            }
        }


        private void saveBook()
        {
            Database db = new Database();

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Books(Name,Author,Category) VALUES(@Name,@Author,@Category) ", db.Connection());
                command.Parameters.AddWithValue("@Name", textBoxName.Text.Trim());
                command.Parameters.AddWithValue("@Author", textBoxAuthor.Text.Trim());
                command.Parameters.AddWithValue("@Category", textBoxCategory.Text.Trim());

                command.ExecuteNonQuery();
                db.Connection().Close();
                clearAddBookForm();
                Response.Write("<script>alert('Kitap Eklendi');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void goBack()
        {
            Response.Redirect("BookList.aspx");
        }

        private void clearAddBookForm()
        {
            textBoxName.Text = "";
            textBoxAuthor.Text = "";
            textBoxCategory.Text = "";
        }
    }
}