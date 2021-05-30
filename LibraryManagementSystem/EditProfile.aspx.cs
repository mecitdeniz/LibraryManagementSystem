using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class EditProfile : System.Web.UI.Page
    {

        private User user = new User(-1, "", "", "");

        protected void Page_Load(object sender, EventArgs e)
        {
            (this.Master as Site1).changeButtonCss("btnEditProfile");
            getUserID();
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            goBack();
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            //Get Values
            string oldPassword = textBoxPassword.Text.Trim().ToString();
            string newPassword = textBoxNewPassword.Text.Trim().ToString();
            string confirmPassword = textBoxConfirmPassword.Text.Trim().ToString();
            
            getUserID();

            //Validate Form
            bool isPasswordsMatch = validatePassword(newPassword,confirmPassword);
            
            if(isPasswordsMatch && !string.IsNullOrEmpty(oldPassword))
            {
                updateUserPassword(oldPassword,newPassword);
            }
            else Response.Write("<script>alert('Girdiğiniz şifreler uyuşmuyor!');</script>");
        }


        private bool validatePassword(string password,string confirmPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword)) return false;
            
            if (!password.Equals(confirmPassword)) return false;
            return true;
        }


        public void getUserID()
        {
            try
            {
                user.ID = int.Parse(Session["ID"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.Redirect("Login.aspx");
            }
        }

        private void updateUserPassword(string oldPassword,string newPassword)
        {
            try
            {
                //Response.Write("<script>alert('" + user.ID + "');</script>");

                Database db = new Database();
                SqlCommand command = new SqlCommand("UPDATE Users SET Password=@Password" +
                " where ID='" + user.ID + "' and Password= '"+oldPassword+"'", db.Connection());

                command.Parameters.AddWithValue("@Password", newPassword);

                command.ExecuteNonQuery();
                Response.Write("<script>alert('Şifreniz başarıyla güncellendi! :)');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Hay Aksi! Lütfen eski şifrenizi doğru girdiğinizden emin olunuz!');</script>");
            }
        }

        public void goBack()
        {
            Response.Redirect("UserList.aspx");
        }
    }
}