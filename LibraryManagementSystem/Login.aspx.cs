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

        private User user = new User(0,"","","");

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Database db = new Database();


                SqlCommand command = new SqlCommand("SELECT * from Users where Username='" +
                    textBoxUsername.Text.Trim() + "' AND Password='" +
                    textBoxPassword.Text.Trim() + "' AND isAdmin='" + checkBoxAdmin.Checked + "'", db.Connection());

                SqlDataReader sqlDataReader = command.ExecuteReader();
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
                            Session.Add("ID",user.ID);
                            Session.Add("FULLNAME",user.FullName);
                            Session.Add("USERNAME",user.UserName);
                            Response.Redirect("UserList.aspx");
                        }
                        else
                        {
                            Session.Add("ROLE", "USER");
                            Session.Add("ID", user.ID);
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
    }
}