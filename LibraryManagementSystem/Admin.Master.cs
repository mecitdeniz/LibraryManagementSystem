using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            isAdmin();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
        }

        public void isAdmin()
        {
            try
            {
                if (Session["ROLE"].Equals("") || Session["ROLE"].Equals("User"))
                {
                    Response.Redirect("WebForm1.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("WebForm1.aspx");
            }
        }
    }
}