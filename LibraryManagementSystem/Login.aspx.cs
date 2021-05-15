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
                        string isAdmin = sqlDataReader.GetValue(4).ToString();
                        if (isAdmin.Equals("True"))
                        {
                            Session.Add("ROLE", "ADMIN");
                            Response.Redirect("UserList.aspx");
                        }
                        else
                        {
                            Session.Add("ROLE", "USER");
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