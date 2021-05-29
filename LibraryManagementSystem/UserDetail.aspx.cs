using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class UserDetail : System.Web.UI.Page
    {
        private User user = new User(0, "", "", "");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["userID"]))
            {
                user.ID = Int32.Parse(Request.QueryString["userID"]);
                (this.Master as Site1).changeButtonCss("btnUserList");
                getUser();
                gridViewReturnedBookList.Visible = false;
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
        protected void btnShowNotReturned_Click(object sender, EventArgs e)
        {
            bool isVisible = gridViewNotReturnedBookList.Visible;
            if (isVisible)
            {
                gridViewNotReturnedBookList.Visible = false;
                gridViewReturnedBookList.Visible = true;
            }
            else
            {
                gridViewReturnedBookList.Visible = false;
                gridViewNotReturnedBookList.Visible = true;
            }
        }
        protected void gridViewBookListRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RETURNBOOK")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gridViewNotReturnedBookList.Rows[index];

                int id = int.Parse(row.Cells[0].Text.ToString());

                returnBook(id);
                gridViewNotReturnedBookList.DataBind();
                gridViewReturnedBookList.DataBind();
            }
            
            if (e.CommandName == "BOOKDETAIL")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gridViewNotReturnedBookList.Rows[index];

                int id = int.Parse(row.Cells[0].Text.ToString());
                Response.Redirect("RentDetail.aspx?rentID=" + id);

            }
        }

        protected void gridViewReturnedBookListRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "BOOKDETAIL")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gridViewReturnedBookList.Rows[index];

                int id = int.Parse(row.Cells[0].Text.ToString());
                Response.Redirect("RentDetail.aspx?rentID=" + id);
            }
        }


        private void returnBook(int bookID)
        {
            try
            {
                Database db = new Database();
                SqlCommand command = new SqlCommand("UPDATE RentBook SET isReturned = 1, ReturnAt=(GETDATE()) WHERE BookID = '" + bookID + "'  AND UserID= '" + user.ID + "' AND isReturned = 0", db.Connection());
                command.ExecuteNonQuery();
                db.Connection().Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void getUser()
        {
            try
            {
                Database db = new Database();
                SqlCommand command = new SqlCommand("SELECT * from Users where ID='" + user.ID + "'", db.Connection());

                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        user.FullName = sqlDataReader.GetValue(1).ToString();
                        user.UserName = sqlDataReader.GetValue(2).ToString();
                        user.Password = sqlDataReader.GetValue(3).ToString();

                        labelFullName.Text = user.FullName;
                        labelBoxUserName.Text = "@" + user.UserName;
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