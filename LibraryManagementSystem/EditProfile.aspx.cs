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
            
            if(string.IsNullOrEmpty(oldPassword))
            {
                Response.Write("<script>alert('Lütfen formu eksiksiz doldurunuz!');</script>");
                return;
            }

            if (!isPasswordsMatch)
            {
                Response.Write("<script>alert('Girdiğiniz şifreler uyuşmuyor!');</script>");
                return;
            }
            
            //Validate oldPassword
            bool isPasswordCorrect = validateOldPassword(oldPassword);
            if(!isPasswordCorrect)
            {
                Response.Write("<script>alert('Şifreniz hatalı!');</script>");
                return;
            }

            updateUserPassword(oldPassword, newPassword);

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


        private bool validateOldPassword(string password)
        {
            try
            {
                Database db = new Database();

                SqlCommand command = new SqlCommand("SELECT * from Users where ID='" +
                    user.ID + "' AND Password='" + password + "'", db.Connection());

                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
            
        }

        private void updateUserPassword(string oldPassword,string newPassword)
        {
            try
            {
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