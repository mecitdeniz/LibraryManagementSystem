using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (this.Master as Site1).changeButtonCss("btnUserList");
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserList.aspx");
        }


        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (textBoxFullName.Text != "" && textBoxUsername.Text != "" && textBoxPassword.Text != "")
            {
                saveUser();
            }
            else{
                Response.Write("<script>alert('Lütfen Formu Doldurunuz!');</script>");
            }
        }


        private void saveUser()
        {
            Database db = new Database();

            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Users(FullName,Username,Password,isAdmin) VALUES(@FullName,@Username,@Password,@isAdmin) ", db.Connection());
                command.Parameters.AddWithValue("@FullName", textBoxFullName.Text.Trim());
                command.Parameters.AddWithValue("@Username", textBoxUsername.Text.Trim());
                command.Parameters.AddWithValue("@Password", textBoxPassword.Text.Trim());
                command.Parameters.AddWithValue("@isAdmin", false);

                command.ExecuteNonQuery();
                db.Connection().Close(); 
                clearAddUserForm();
                Response.Write("<script>alert('Kullanıcı Eklendi');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }

        private void clearAddUserForm()
        {
            textBoxFullName.Text = "";
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
        }
    }
}