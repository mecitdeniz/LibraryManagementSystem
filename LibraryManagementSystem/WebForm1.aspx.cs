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

            Database db = new Database();
            SqlCommand command = new SqlCommand("SELECT * from Users", db.Connection());

            SqlDataReader sqlDataReader = command.ExecuteReader();
            Console.WriteLine(sqlDataReader);
        }
    }
}