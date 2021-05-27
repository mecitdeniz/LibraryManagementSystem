using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class RentDetail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["rentID"]))
            {
                int id = Int32.Parse(Request.QueryString["rentID"]);
                getRentDetail(id);
            }
            else
            {
                goBack();
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            goBack();
        }


        private void getRentDetail(int rentID)
        {
            try
            {
                Database db = new Database();
                SqlCommand command = new SqlCommand("SELECT " +
                    "Users.FullName," +
                    "Users.Username," +
                    "Books.Name," +
                    "Books.Author," +
                    "Books.Category," +
                    "RentBook.CreatedAt," +
                    "RentBook.ReturnAt," +
                    "RentBook.Deadline," +
                    "RentBook.isReturned" +
                    " FROM Users " +
                    "JOIN RentBook ON " +
                    "Users.ID = RentBook.UserID " +
                    "JOIN Books" +
                    " ON Books.ID = RentBook.BookID " +
                    "WHERE RentBook.ID = '"+ rentID + "'; ",
                    db.Connection());

                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        labelFullName.Text = sqlDataReader.GetValue(0).ToString();
                        labelUsername.Text = sqlDataReader.GetValue(1).ToString();
                        labelBookName.Text = sqlDataReader.GetValue(2).ToString();
                        labelAuthor.Text = sqlDataReader.GetValue(3).ToString();
                        labelCategory.Text = sqlDataReader.GetValue(4).ToString();
                        labelRentDate.Text = sqlDataReader.GetValue(5).ToString();
                        labelReturnDate.Text = sqlDataReader.GetValue(6).ToString();
                        labelDeadline.Text = sqlDataReader.GetValue(7).ToString();
                        
                        bool status = bool.Parse(sqlDataReader.GetValue(8).ToString());
                        if(status == false)
                        {
                            labelStatus.Text = "Teslim Edilmedi";
                            labelStatus.ForeColor = System.Drawing.Color.Red;
                        }

                        if(status == true)
                        {
                            labelStatus.Text = "Teslim Edildi";
                            labelStatus.ForeColor = System.Drawing.Color.Cyan;
                        }


                    }
                }
                db.Connection().Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void goBack()
        {
            Response.Redirect("UserList.aspx");
        }
    }
}