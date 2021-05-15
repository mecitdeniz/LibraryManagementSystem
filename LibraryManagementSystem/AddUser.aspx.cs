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

        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserList.aspx");
        }


        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Tıklandı');</script>");
            saveUser();
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
                command.Parameters.AddWithValue("@isAdmin", checkBoxISAdmin.Checked);

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
            checkBoxISAdmin.Checked = false;
        }
    }
}