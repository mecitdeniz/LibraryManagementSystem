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

                /*
                 * TODO 
                 * Implement Validation to avoid Sql injection
                 */

                SqlCommand command = new SqlCommand("SELECT * from Users where Username='" +
                    textBoxUsername.Text.Trim() + "' AND Password='" +
                    textBoxPassword.Text.Trim() + "' AND isAdmin='"+checkBoxAdmin.Checked+"'", db.Connection());

                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {

                        /*
                         * TODO
                         * if admin redirect to the admin panel
                         * else redirect to the student panel
                         * 
                         */
                        Response.Write("<script>alert('"+sqlDataReader.GetValue(5).ToString()+"');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials');</script>");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}