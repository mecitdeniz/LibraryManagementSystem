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
        private User user = new User(0,"","","");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["userID"]))
            {
                user.ID = Int32.Parse(Request.QueryString["userID"]);
                (this.Master as Site1).changeButtonCss("btnUserList");
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
            setUserFields();
            updateUser();
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
                        
                        textBoxFullName.Attributes.Add("placeholder", user.FullName);
                        textBoxUsername.Attributes.Add("placeholder", user.UserName);
                        textBoxPassword.Attributes.Add("placeholder", user.Password);
                    }
                }
                db.Connection().Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        private void setUserFields()
        {
            if(user.FullName != textBoxFullName.Text && textBoxFullName.Text != "")
            {
                user.FullName = textBoxFullName.Text.Trim();
            }

            if(user.UserName != textBoxUsername.Text && textBoxUsername.Text != "")
            {
                user.UserName = textBoxUsername.Text.Trim();
            }

            if(user.Password != textBoxPassword.Text && textBoxPassword.Text != "")
            {
                user.Password = textBoxPassword.Text.Trim();
            }
        }

        private void updateUser()
        {
            try
            {
                Response.Write("<script>alert('" + user.ID + "');</script>");

                Database db = new Database();
                SqlCommand command = new SqlCommand("UPDATE Users SET FullName=@FullName," +
                    " Username=@Username, Password=@Password" +
                    " where ID='" + user.ID + "'", db.Connection());

                command.Parameters.AddWithValue("@FullName",user.FullName);
                command.Parameters.AddWithValue("@Username",user.UserName);
                command.Parameters.AddWithValue("@Password",user.Password);

                command.ExecuteNonQuery();
                Response.Write("<script>alert('Kullanıcı Güncellendi');</script>");
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