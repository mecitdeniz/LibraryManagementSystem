using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class UpdateBook : System.Web.UI.Page
    {
        private Book book = new Book(0, "", "", "");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["bookID"]))
            {
                book.ID = Int32.Parse(Request.QueryString["bookID"]);
                getBook();
            }
            else
            {
                goBack();
                textBoxName.Text = "NO DATA PROVIDED OR COULD NOT BE READ";
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            goBack();
        }

        protected void btnUpdateBook_Click(object sender, EventArgs e)
        {
            setBookFields();
            updateBook();
        }

        private void getBook()
        {
            try
            {
                Database db = new Database();
                SqlCommand command = new SqlCommand("SELECT * from Books where ID='" + book.ID + "'", db.Connection());

                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        book.Name = sqlDataReader.GetValue(1).ToString();
                        book.Author = sqlDataReader.GetValue(2).ToString();
                        book.Category = sqlDataReader.GetValue(3).ToString();

                        textBoxName.Attributes.Add("placeholder", book.Name);
                        textBoxAuthor.Attributes.Add("placeholder", book.Author);
                        textBoxCategory.Attributes.Add("placeholder", book.Category);
                    }
                }
                db.Connection().Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        private void setBookFields()
        {
            if (book.Name != textBoxName.Text && textBoxName.Text != "")
            {
                book.Name = textBoxName.Text.Trim();
            }

            if (book.Author != textBoxAuthor.Text && textBoxAuthor.Text != "")
            {
                book.Author = textBoxAuthor.Text.Trim();
            }

            if (book.Category != textBoxCategory.Text && textBoxCategory.Text != "")
            {
                book.Category = textBoxCategory.Text.Trim();
            }
        }

        private void updateBook()
        {
            try
            {
                Database db = new Database();
                SqlCommand command = new SqlCommand("UPDATE Books SET Name=@Name," +
                    " Author=@Author, Category=@Category" +
                    " where ID='" + book.ID + "'", db.Connection());

                command.Parameters.AddWithValue("@Name", book.Name);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Category", book.Category);

                command.ExecuteNonQuery();
                Response.Write("<script>alert('Kitpa Güncellendi');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void goBack()
        {
            Response.Redirect("BookList.aspx");
        }
    }

}