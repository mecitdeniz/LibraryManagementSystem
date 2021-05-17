using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        private int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["userID"]))
            {
                userID = Int32.Parse(Request.QueryString["userID"]);
                getUser();
            }
            else
            {
                goBack();
                textBoxFullName.Text = "NO DATA PROVIDED OR COULD NOT BE READ";
            }
        }
        
        protected void btnBack_Click(object sender, EventArgs e)
        {
            goBack();
        }
        
        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            updateUser();
        }

        private void getUser()
        {
            try
            {
                Database db = new Database();
                SqlCommand command = new SqlCommand("SELECT * from Users where ID='"+userID+"'", db.Connection());

                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        textBoxFullName.Text = sqlDataReader.GetValue(1).ToString();
                        textBoxUsername.Text = sqlDataReader.GetValue(2).ToString();
                        textBoxPassword.Text = sqlDataReader.GetValue(3).ToString();
                        checkBoxISAdmin.Checked = bool.Parse(sqlDataReader.GetValue(4).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        private void updateUser()
        {
            Response.Write("<script>alert('" + userID + "');</script>");
            /*

            try
            {
                Database db = new Database();
                SqlCommand command = new SqlCommand("UPDATE Users SET FullName=@FullName,Username=@Username,Password=@Password,isAdmin=@isAdmin WHERE ID='"+userID+"'", db.Connection());
                command.Parameters.AddWithValue("@FullName", textBoxFullName.Text.Trim());
                command.Parameters.AddWithValue("@Username", textBoxUsername.Text.Trim());
                command.Parameters.AddWithValue("@Password", textBoxPassword.Text.Trim());
                command.Parameters.AddWithValue("@isAdmin", checkBoxISAdmin.Checked);

                command.ExecuteNonQuery();
                db.Connection().Close();
                Response.Write("<script>alert('Kullanıcı Güncellendi');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }*/
        }

        public void goBack()
        {
            Response.Redirect("UserList.aspx");
        }
    }
}