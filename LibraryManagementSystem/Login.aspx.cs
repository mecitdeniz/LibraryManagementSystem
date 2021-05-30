using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User(0, "", "", "");

            user.UserName = textBoxUsername.Text.Trim();
            user.Password = textBoxPassword.Text.Trim();
            
            bool isFormCompleted = validateForm(user.UserName,user.Password);
            if (!isFormCompleted)
            {
                Response.Write("<script>alert('Hay Aksi:( Lütfen formu eksiksiz doldurunuz!');</script>");
                return;
            }
            login(user.UserName,user.Password);

        }

        private bool validateForm(string username,string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return false;
            return true;
        }

        private void login(string username,string password)
        {
            try
            {
                Database db = new Database();

                SqlCommand command = new SqlCommand("SELECT * from Users where Username='" + username
                     + "' AND Password='" +
                     password + "' AND isAdmin='" + checkBoxAdmin.Checked + "'", db.Connection());

                SqlDataReader sqlDataReader = command.ExecuteReader();
                User user = new User(0, "", "", "");

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        user.ID = int.Parse(sqlDataReader.GetValue(0).ToString());
                        user.FullName = sqlDataReader.GetValue(1).ToString();
                        user.UserName = sqlDataReader.GetValue(2).ToString();
                        string isAdmin = sqlDataReader.GetValue(4).ToString();

                        if (isAdmin.Equals("True"))
                        {
                            Session.Add("ROLE", "ADMIN");
                            Session.Add("ID", user.ID);
                            Session.Add("FULLNAME", user.FullName);
                            Session.Add("USERNAME", user.UserName);
                            Response.Redirect("UserList.aspx");
                        }
                        else
                        {
                            Session.Add("ROLE", "USER");
                            Session.Add("ID", user.ID);
                            Session.Add("FULLNAME", user.FullName);
                            Session.Add("USERNAME", user.UserName);
                            Response.Redirect("AllBooksList.aspx");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Hay Aksi:( Girdiğiniz bilgiler yanlış!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}